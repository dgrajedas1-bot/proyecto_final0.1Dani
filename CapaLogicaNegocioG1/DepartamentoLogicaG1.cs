using System;
using System.Data;
using CapaAccesoDatosG1;
using CapaEntidadesG1;

namespace CapaLogicaNegocioG1
{
    /// <summary>
    /// Reglas de negocio para los departamentos.
    /// </summary>
    public class DepartamentoLogicaG1
    {
        private readonly DepartamentoDatosG1 gObjDatosG1 = new DepartamentoDatosG1();

        /// <summary>Lista todos los departamentos.</summary>
        /// <returns>Tabla de departamentos.</returns>
        public DataTable FunListarG1()
        {
            return ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunListarG1());
        }

        /// <summary>Busca un departamento por ID.</summary>
        /// <param name="intIdG1">ID del departamento.</param>
        /// <returns>El departamento o null.</returns>
        public DepartamentoG1 FunBuscarG1(int intIdG1)
        {
            if (intIdG1 <= 0) throw new ArgumentException("El ID debe ser un número mayor que cero.");
            return ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunBuscarPorIdG1(intIdG1));
        }

        /// <summary>Valida y guarda un departamento nuevo.</summary>
        /// <param name="strNombreG1">Nombre del departamento.</param>
        public void SubGuardarG1(string strNombreG1)
        {
            string strLimpioG1 = FunValidarNombreG1(strNombreG1, 0);
            ErroresLogicaG1.SubEjecutarG1(() => gObjDatosG1.SubInsertarG1(new DepartamentoG1 { NombreDepartamentoG1 = strLimpioG1 }));
        }

        /// <summary>Valida y actualiza un departamento.</summary>
        /// <param name="intIdG1">ID del departamento.</param>
        /// <param name="strNombreG1">Nombre nuevo.</param>
        public void SubActualizarG1(int intIdG1, string strNombreG1)
        {
            if (intIdG1 <= 0) throw new ArgumentException("Seleccione un departamento de la lista para editarlo.");
            string strLimpioG1 = FunValidarNombreG1(strNombreG1, intIdG1);
            int intFilasG1 = ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunActualizarG1(
                new DepartamentoG1 { IdDepartamentoG1 = intIdG1, NombreDepartamentoG1 = strLimpioG1 }));
            if (intFilasG1 == 0) throw new ArgumentException("El departamento ya no existe.");
        }

        /// <summary>Elimina un departamento si no tiene empleados.</summary>
        /// <param name="intIdG1">ID del departamento.</param>
        public void SubEliminarG1(int intIdG1)
        {
            if (intIdG1 <= 0) throw new ArgumentException("El ID debe ser un número mayor que cero.");
            int intEmpleadosG1 = ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunContarEmpleadosG1(intIdG1));
            if (intEmpleadosG1 > 0)
                throw new ArgumentException("No se puede eliminar: el departamento tiene " + intEmpleadosG1 + " empleado(s).");
            int intFilasG1 = ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunEliminarG1(intIdG1));
            if (intFilasG1 == 0) throw new ArgumentException("No existe un departamento con ese ID.");
        }

        /// <summary>Valida el nombre: requerido, máximo 100 caracteres y sin duplicados.</summary>
        /// <param name="strNombreG1">Nombre ingresado.</param>
        /// <param name="intIdExcluirG1">ID a excluir en la validación de duplicados.</param>
        /// <returns>Nombre sin espacios sobrantes.</returns>
        private string FunValidarNombreG1(string strNombreG1, int intIdExcluirG1)
        {
            string strLimpioG1 = (strNombreG1 ?? "").Trim();
            if (strLimpioG1.Length == 0) throw new ArgumentException("Ingrese el nombre del departamento.");
            if (strLimpioG1.Length > 100) throw new ArgumentException("El nombre no puede tener más de 100 caracteres.");
            if (ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunExisteNombreG1(strLimpioG1, intIdExcluirG1)))
                throw new ArgumentException("Ya existe un departamento con ese nombre.");
            return strLimpioG1;
        }
    }
}
