using System;
using System.Data.SqlClient;

namespace CapaLogicaNegocioG1
{
    /// <summary>
    /// Convierte los errores de SQL Server en mensajes claros para el usuario.
    /// </summary>
    public static class ErroresLogicaG1
    {
        /// <summary>
        /// Ejecuta una operación de datos y traduce cualquier SqlException a un mensaje amigable.
        /// </summary>
        /// <typeparam name="T">Tipo que devuelve la operación.</typeparam>
        /// <param name="funOperacionG1">Operación a ejecutar.</param>
        /// <returns>El resultado de la operación.</returns>
        public static T FunEjecutarG1<T>(Func<T> funOperacionG1)
        {
            try
            {
                return funOperacionG1();
            }
            catch (SqlException exSqlG1)
            {
                throw new InvalidOperationException(FunTraducirG1(exSqlG1), exSqlG1);
            }
        }

        /// <summary>
        /// Ejecuta una operación de datos sin valor de retorno.
        /// </summary>
        /// <param name="subOperacionG1">Operación a ejecutar.</param>
        public static void SubEjecutarG1(Action subOperacionG1)
        {
            FunEjecutarG1<bool>(() => { subOperacionG1(); return true; });
        }

        /// <summary>
        /// Devuelve un mensaje en español según el número de error de SQL Server.
        /// </summary>
        /// <param name="exSqlG1">Excepción original.</param>
        /// <returns>Mensaje para mostrar.</returns>
        public static string FunTraducirG1(SqlException exSqlG1)
        {
            switch (exSqlG1.Number)
            {
                case 2627:
                case 2601:
                    return "Ya existe un registro con esos datos (valor duplicado).";
                case 547:
                    return "No se puede completar la operación porque el registro está relacionado con otros datos.";
                case 4060:
                case 18456:
                    return "No se pudo abrir la base de datos ControlAsistenciaDB. Verifique que ejecutó el script BaseDatos/ControlAsistenciaDB.sql.";
                case -2:
                    return "La base de datos tardó demasiado en responder. Intente de nuevo.";
                case 2:
                case 53:
                case -1:
                    return "No se pudo conectar a SQL Server. Verifique que SQL Express esté iniciado y la cadena de conexión en App.config.";
                default:
                    return "Error de base de datos: " + exSqlG1.Message;
            }
        }
    }
}
