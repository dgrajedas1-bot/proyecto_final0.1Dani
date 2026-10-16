using System;
using System.Data;
using System.Linq;
using CapaAccesoDatosG1;
using CapaEntidadesG1;

namespace CapaLogicaNegocioG1
{
    /// <summary>
    /// Reglas de negocio para los empleados (código de 3 dígitos, datos requeridos, salario).
    /// </summary>
    public class EmpleadoLogicaG1
    {
        private readonly EmpleadoDatosG1 gObjDatosG1 = new EmpleadoDatosG1();

        /// <summary>
        /// Valida un código de empleado y lo devuelve con formato 001.
        /// Acepta "1", "01" o "001" y devuelve "001".
        /// </summary>
        /// <param name="strCodigoG1">Código ingresado.</param>
        /// <returns>Código con 3 dígitos.</returns>
        public static string FunNormalizarCodigoG1(string strCodigoG1)
        {
            string strLimpioG1 = (strCodigoG1 ?? "").Trim();
            if (strLimpioG1.Length == 0) throw new ArgumentException("Ingrese el código del empleado.");
            if (!strLimpioG1.All(char.IsDigit)) throw new ArgumentException("El código del empleado solo puede tener números.");
            if (strLimpioG1.Length > 3) throw new ArgumentException("El código del empleado debe tener 3 dígitos (ejemplo: 001).");
            int intCodigoG1 = int.Parse(strLimpioG1);
            if (intCodigoG1 < 1) throw new ArgumentException("El código del empleado debe estar entre 001 y 999.");
            return intCodigoG1.ToString("000");
        }

        /// <summary>Lista empleados con filtro opcional.</summary>
        /// <param name="strFiltroG1">Texto de búsqueda.</param>
        /// <returns>Tabla de empleados.</returns>
        public DataTable FunListarG1(string strFiltroG1)
        {
            return ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunListarG1((strFiltroG1 ?? "").Trim()));
        }

        /// <summary>Lista empleados activos para listas desplegables.</summary>
        /// <returns>Tabla con IdEmpleado y NombreCompleto.</returns>
        public DataTable FunListarActivosG1()
        {
            return ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunListarActivosG1());
        }

        /// <summary>Busca un empleado por código.</summary>
        /// <param name="strCodigoG1">Código ingresado.</param>
        /// <returns>El empleado o null.</returns>
        public EmpleadoG1 FunBuscarPorCodigoG1(string strCodigoG1)
        {
            string strCodigoNormalizadoG1 = FunNormalizarCodigoG1(strCodigoG1);
            return ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunBuscarPorCodigoG1(strCodigoNormalizadoG1));
        }

        /// <summary>Devuelve el siguiente código libre (001, 002...).</summary>
        /// <returns>Código sugerido.</returns>
        public string FunSiguienteCodigoG1()
        {
            return ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunSiguienteCodigoG1());
        }

        /// <summary>Valida y guarda un empleado nuevo.</summary>
        /// <param name="objEmpleadoG1">Datos del empleado.</param>
        public void SubGuardarG1(EmpleadoG1 objEmpleadoG1)
        {
            SubValidarG1(objEmpleadoG1, 0);
            ErroresLogicaG1.SubEjecutarG1(() => gObjDatosG1.SubInsertarG1(objEmpleadoG1));
        }

        /// <summary>Valida y actualiza un empleado.</summary>
        /// <param name="objEmpleadoG1">Datos del empleado (con IdEmpleado).</param>
        public void SubActualizarG1(EmpleadoG1 objEmpleadoG1)
        {
            if (objEmpleadoG1 == null || objEmpleadoG1.IdEmpleado <= 0)
                throw new ArgumentException("Seleccione un empleado de la lista para editarlo.");
            SubValidarG1(objEmpleadoG1, objEmpleadoG1.IdEmpleado);
            if (ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunActualizarG1(objEmpleadoG1)) == 0)
                throw new ArgumentException("El empleado ya no existe.");
        }

        /// <summary>
        /// Elimina un empleado. Si ya tiene marcaciones o turnos, lo desactiva para conservar el historial.
        /// </summary>
        /// <param name="intIdG1">ID del empleado.</param>
        /// <returns>True si se eliminó; false si solo se desactivó.</returns>
        public bool FunEliminarG1(int intIdG1)
        {
            if (intIdG1 <= 0) throw new ArgumentException("Seleccione un empleado de la lista.");
            if (ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunTieneHistorialG1(intIdG1)))
            {
                ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunDesactivarG1(intIdG1));
                return false;
            }
            if (ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunEliminarG1(intIdG1)) == 0)
                throw new ArgumentException("El empleado ya no existe.");
            return true;
        }

        /// <summary>Valida los datos requeridos, longitudes, salario y código único.</summary>
        /// <param name="objEmpleadoG1">Empleado a validar (el código queda normalizado).</param>
        /// <param name="intIdExcluirG1">ID a excluir en la validación de código duplicado.</param>
        private void SubValidarG1(EmpleadoG1 objEmpleadoG1, int intIdExcluirG1)
        {
            if (objEmpleadoG1 == null) throw new ArgumentException("No hay datos del empleado.");
            objEmpleadoG1.CodigoCarnet = FunNormalizarCodigoG1(objEmpleadoG1.CodigoCarnet);
            objEmpleadoG1.Nombres = (objEmpleadoG1.Nombres ?? "").Trim();
            objEmpleadoG1.Apellidos = (objEmpleadoG1.Apellidos ?? "").Trim();
            objEmpleadoG1.Puesto = (objEmpleadoG1.Puesto ?? "").Trim();
            if (objEmpleadoG1.Nombres.Length == 0) throw new ArgumentException("Ingrese los nombres del empleado.");
            if (objEmpleadoG1.Apellidos.Length == 0) throw new ArgumentException("Ingrese los apellidos del empleado.");
            if (objEmpleadoG1.Nombres.Length > 100 || objEmpleadoG1.Apellidos.Length > 100)
                throw new ArgumentException("Nombres y apellidos no pueden tener más de 100 caracteres.");
            if (objEmpleadoG1.Puesto.Length == 0) throw new ArgumentException("Ingrese el puesto del empleado.");
            if (objEmpleadoG1.Puesto.Length > 100) throw new ArgumentException("El puesto no puede tener más de 100 caracteres.");
            if (objEmpleadoG1.IdDepartamento <= 0) throw new ArgumentException("Seleccione un departamento.");
            if (objEmpleadoG1.SalarioBase <= 0 || objEmpleadoG1.SalarioBase > 99999999m)
                throw new ArgumentException("El salario base debe ser mayor que cero.");
            string strCodigoG1 = objEmpleadoG1.CodigoCarnet;
            if (ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunExisteCodigoG1(strCodigoG1, intIdExcluirG1)))
                throw new ArgumentException("El código " + strCodigoG1 + " ya está asignado a otro empleado.");
        }
    }
}
