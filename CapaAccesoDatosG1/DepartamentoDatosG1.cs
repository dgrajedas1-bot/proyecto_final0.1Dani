using System.Data;
using CapaEntidadesG1;

namespace CapaAccesoDatosG1
{
    /// <summary>
    /// Acceso a datos de la tabla Departamentos.
    /// </summary>
    public class DepartamentoDatosG1
    {
        /// <summary>Lista todos los departamentos.</summary>
        /// <returns>Tabla con IdDepartamento y NombreDepartamento.</returns>
        public DataTable FunListarG1()
        {
            return ConexionG1.FunConsultarG1(
                "SELECT IdDepartamento, NombreDepartamento FROM Departamentos ORDER BY IdDepartamento");
        }

        /// <summary>Busca un departamento por su ID.</summary>
        /// <param name="intIdG1">ID del departamento.</param>
        /// <returns>El departamento o null si no existe.</returns>
        public DepartamentoG1 FunBuscarPorIdG1(int intIdG1)
        {
            DataTable dtG1 = ConexionG1.FunConsultarG1(
                "SELECT IdDepartamento, NombreDepartamento FROM Departamentos WHERE IdDepartamento = @id",
                ConexionG1.FunParametroG1("@id", intIdG1));
            if (dtG1.Rows.Count == 0) return null;
            return new DepartamentoG1
            {
                IdDepartamentoG1 = (int)dtG1.Rows[0]["IdDepartamento"],
                NombreDepartamentoG1 = dtG1.Rows[0]["NombreDepartamento"].ToString()
            };
        }

        /// <summary>Indica si ya existe un departamento con ese nombre (excluyendo un ID).</summary>
        /// <param name="strNombreG1">Nombre a validar.</param>
        /// <param name="intIdExcluirG1">ID que no se toma en cuenta (0 para ninguno).</param>
        /// <returns>True si el nombre ya existe.</returns>
        public bool FunExisteNombreG1(string strNombreG1, int intIdExcluirG1)
        {
            object objG1 = ConexionG1.FunEscalarG1(
                "SELECT COUNT(*) FROM Departamentos WHERE NombreDepartamento = @nombre AND IdDepartamento <> @id",
                ConexionG1.FunParametroG1("@nombre", strNombreG1), ConexionG1.FunParametroG1("@id", intIdExcluirG1));
            return System.Convert.ToInt32(objG1) > 0;
        }

        /// <summary>Cuenta los empleados que pertenecen a un departamento.</summary>
        /// <param name="intIdG1">ID del departamento.</param>
        /// <returns>Cantidad de empleados.</returns>
        public int FunContarEmpleadosG1(int intIdG1)
        {
            return System.Convert.ToInt32(ConexionG1.FunEscalarG1(
                "SELECT COUNT(*) FROM Empleados WHERE IdDepartamento = @id", ConexionG1.FunParametroG1("@id", intIdG1)));
        }

        /// <summary>Inserta un departamento.</summary>
        /// <param name="objDeptoG1">Departamento a guardar.</param>
        public void SubInsertarG1(DepartamentoG1 objDeptoG1)
        {
            ConexionG1.FunEjecutarG1("INSERT INTO Departamentos (NombreDepartamento) VALUES (@nombre)",
                ConexionG1.FunParametroG1("@nombre", objDeptoG1.NombreDepartamentoG1));
        }

        /// <summary>Actualiza el nombre de un departamento.</summary>
        /// <param name="objDeptoG1">Departamento con los datos nuevos.</param>
        /// <returns>Filas afectadas.</returns>
        public int FunActualizarG1(DepartamentoG1 objDeptoG1)
        {
            return ConexionG1.FunEjecutarG1("UPDATE Departamentos SET NombreDepartamento = @nombre WHERE IdDepartamento = @id",
                ConexionG1.FunParametroG1("@nombre", objDeptoG1.NombreDepartamentoG1),
                ConexionG1.FunParametroG1("@id", objDeptoG1.IdDepartamentoG1));
        }

        /// <summary>Elimina un departamento.</summary>
        /// <param name="intIdG1">ID del departamento.</param>
        /// <returns>Filas afectadas.</returns>
        public int FunEliminarG1(int intIdG1)
        {
            return ConexionG1.FunEjecutarG1("DELETE FROM Departamentos WHERE IdDepartamento = @id",
                ConexionG1.FunParametroG1("@id", intIdG1));
        }
    }
}
