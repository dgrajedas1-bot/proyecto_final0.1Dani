using System;
using System.Data;
using CapaEntidadesG1;

namespace CapaAccesoDatosG1
{
    /// <summary>
    /// Acceso a datos de la tabla Empleados.
    /// </summary>
    public class EmpleadoDatosG1
    {
        /// <summary>Lista los empleados con el nombre de su departamento.</summary>
        /// <param name="strFiltroG1">Texto para filtrar por código, nombre o apellido (vacío = todos).</param>
        /// <returns>Tabla de empleados.</returns>
        public DataTable FunListarG1(string strFiltroG1)
        {
            return ConexionG1.FunConsultarG1(
                "SELECT e.IdEmpleado, e.CodigoCarnet AS Codigo, e.Nombres, e.Apellidos, e.IdDepartamento, " +
                "d.NombreDepartamento AS Departamento, e.Puesto, e.SalarioBase, e.Activo " +
                "FROM Empleados e LEFT JOIN Departamentos d ON d.IdDepartamento = e.IdDepartamento " +
                "WHERE @filtro = '' OR e.CodigoCarnet LIKE '%' + @filtro + '%' OR e.Nombres LIKE '%' + @filtro + '%' " +
                "OR e.Apellidos LIKE '%' + @filtro + '%' ORDER BY e.CodigoCarnet",
                ConexionG1.FunParametroG1("@filtro", strFiltroG1 ?? ""));
        }

        /// <summary>Lista los empleados activos para llenar listas desplegables.</summary>
        /// <returns>Tabla con IdEmpleado y NombreCompleto ("001 - Nombre Apellido").</returns>
        public DataTable FunListarActivosG1()
        {
            return ConexionG1.FunConsultarG1(
                "SELECT IdEmpleado, CodigoCarnet + ' - ' + Nombres + ' ' + Apellidos AS NombreCompleto " +
                "FROM Empleados WHERE Activo = 1 ORDER BY CodigoCarnet");
        }

        /// <summary>Busca un empleado por su código de carné.</summary>
        /// <param name="strCodigoG1">Código de 3 dígitos.</param>
        /// <returns>El empleado o null.</returns>
        public EmpleadoG1 FunBuscarPorCodigoG1(string strCodigoG1)
        {
            DataTable dtG1 = ConexionG1.FunConsultarG1("SELECT * FROM Empleados WHERE CodigoCarnet = @codigo",
                ConexionG1.FunParametroG1("@codigo", strCodigoG1));
            return dtG1.Rows.Count == 0 ? null : FunMapearG1(dtG1.Rows[0]);
        }

        /// <summary>Busca un empleado por su ID interno.</summary>
        /// <param name="intIdG1">ID del empleado.</param>
        /// <returns>El empleado o null.</returns>
        public EmpleadoG1 FunBuscarPorIdG1(int intIdG1)
        {
            DataTable dtG1 = ConexionG1.FunConsultarG1("SELECT * FROM Empleados WHERE IdEmpleado = @id",
                ConexionG1.FunParametroG1("@id", intIdG1));
            return dtG1.Rows.Count == 0 ? null : FunMapearG1(dtG1.Rows[0]);
        }

        /// <summary>Indica si el código ya lo usa otro empleado.</summary>
        /// <param name="strCodigoG1">Código a validar.</param>
        /// <param name="intIdExcluirG1">ID que no se toma en cuenta (0 para ninguno).</param>
        /// <returns>True si el código ya existe.</returns>
        public bool FunExisteCodigoG1(string strCodigoG1, int intIdExcluirG1)
        {
            return Convert.ToInt32(ConexionG1.FunEscalarG1(
                "SELECT COUNT(*) FROM Empleados WHERE CodigoCarnet = @codigo AND IdEmpleado <> @id",
                ConexionG1.FunParametroG1("@codigo", strCodigoG1), ConexionG1.FunParametroG1("@id", intIdExcluirG1))) > 0;
        }

        /// <summary>Devuelve el siguiente código disponible en formato 001.</summary>
        /// <returns>Código sugerido.</returns>
        public string FunSiguienteCodigoG1()
        {
            object objG1 = ConexionG1.FunEscalarG1("SELECT MAX(TRY_CAST(CodigoCarnet AS INT)) FROM Empleados");
            int intSiguienteG1 = objG1 == null ? 1 : Convert.ToInt32(objG1) + 1;
            return intSiguienteG1.ToString("000");
        }

        /// <summary>Indica si el empleado tiene marcaciones o turnos asignados.</summary>
        /// <param name="intIdG1">ID del empleado.</param>
        /// <returns>True si tiene historial.</returns>
        public bool FunTieneHistorialG1(int intIdG1)
        {
            return Convert.ToInt32(ConexionG1.FunEscalarG1(
                "SELECT (SELECT COUNT(*) FROM RegistroAsistencia WHERE IdEmpleado = @id) + " +
                "(SELECT COUNT(*) FROM AsignacionTurnos WHERE IdEmpleado = @id)",
                ConexionG1.FunParametroG1("@id", intIdG1))) > 0;
        }

        /// <summary>Inserta un empleado.</summary>
        /// <param name="objEmpleadoG1">Empleado a guardar.</param>
        public void SubInsertarG1(EmpleadoG1 objEmpleadoG1)
        {
            ConexionG1.FunEjecutarG1(
                "INSERT INTO Empleados (CodigoCarnet, Nombres, Apellidos, IdDepartamento, Puesto, SalarioBase, Activo) " +
                "VALUES (@codigo, @nombres, @apellidos, @depto, @puesto, @salario, @activo)",
                FunParametrosG1(objEmpleadoG1));
        }

        /// <summary>Actualiza un empleado.</summary>
        /// <param name="objEmpleadoG1">Empleado con los datos nuevos.</param>
        /// <returns>Filas afectadas.</returns>
        public int FunActualizarG1(EmpleadoG1 objEmpleadoG1)
        {
            return ConexionG1.FunEjecutarG1(
                "UPDATE Empleados SET CodigoCarnet = @codigo, Nombres = @nombres, Apellidos = @apellidos, " +
                "IdDepartamento = @depto, Puesto = @puesto, SalarioBase = @salario, Activo = @activo WHERE IdEmpleado = @id",
                FunParametrosG1(objEmpleadoG1));
        }

        /// <summary>Elimina un empleado sin historial.</summary>
        /// <param name="intIdG1">ID del empleado.</param>
        /// <returns>Filas afectadas.</returns>
        public int FunEliminarG1(int intIdG1)
        {
            return ConexionG1.FunEjecutarG1("DELETE FROM Empleados WHERE IdEmpleado = @id", ConexionG1.FunParametroG1("@id", intIdG1));
        }

        /// <summary>Marca un empleado como inactivo.</summary>
        /// <param name="intIdG1">ID del empleado.</param>
        /// <returns>Filas afectadas.</returns>
        public int FunDesactivarG1(int intIdG1)
        {
            return ConexionG1.FunEjecutarG1("UPDATE Empleados SET Activo = 0 WHERE IdEmpleado = @id", ConexionG1.FunParametroG1("@id", intIdG1));
        }

        /// <summary>Arma los parámetros comunes de inserción y actualización.</summary>
        /// <param name="objEmpleadoG1">Empleado de origen.</param>
        /// <returns>Arreglo de parámetros.</returns>
        private System.Data.SqlClient.SqlParameter[] FunParametrosG1(EmpleadoG1 objEmpleadoG1)
        {
            return new[]
            {
                ConexionG1.FunParametroG1("@id", objEmpleadoG1.IdEmpleado),
                ConexionG1.FunParametroG1("@codigo", objEmpleadoG1.CodigoCarnet),
                ConexionG1.FunParametroG1("@nombres", objEmpleadoG1.Nombres),
                ConexionG1.FunParametroG1("@apellidos", objEmpleadoG1.Apellidos),
                ConexionG1.FunParametroG1("@depto", objEmpleadoG1.IdDepartamento),
                ConexionG1.FunParametroG1("@puesto", objEmpleadoG1.Puesto),
                ConexionG1.FunParametroG1("@salario", objEmpleadoG1.SalarioBase),
                ConexionG1.FunParametroG1("@activo", objEmpleadoG1.Activo)
            };
        }

        /// <summary>Convierte una fila de la tabla Empleados en entidad.</summary>
        /// <param name="drFilaG1">Fila de origen.</param>
        /// <returns>Entidad empleado.</returns>
        private EmpleadoG1 FunMapearG1(DataRow drFilaG1)
        {
            return new EmpleadoG1
            {
                IdEmpleado = Convert.ToInt32(drFilaG1["IdEmpleado"]),
                CodigoCarnet = drFilaG1["CodigoCarnet"].ToString(),
                Nombres = drFilaG1["Nombres"].ToString(),
                Apellidos = drFilaG1["Apellidos"].ToString(),
                IdDepartamento = drFilaG1["IdDepartamento"] == DBNull.Value ? 0 : Convert.ToInt32(drFilaG1["IdDepartamento"]),
                Puesto = drFilaG1["Puesto"].ToString(),
                SalarioBase = Convert.ToDecimal(drFilaG1["SalarioBase"]),
                Activo = drFilaG1["Activo"] != DBNull.Value && Convert.ToBoolean(drFilaG1["Activo"])
            };
        }
    }
}
