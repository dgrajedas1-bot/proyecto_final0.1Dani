using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaAccesoDatosG1
{
    /// <summary>
    /// Administra la conexión a SQL Server Express y ofrece métodos de apoyo
    /// para ejecutar consultas parametrizadas.
    /// </summary>
    public static class ConexionG1
    {
        /// <summary>
        /// Cadena por defecto si App.config no trae "ControlAsistenciaDBG1".
        /// </summary>
        private const string gStrCadenaPorDefectoG1 =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=ControlAsistenciaDB;Integrated Security=True;TrustServerCertificate=True";

        /// <summary>
        /// Crea una conexión nueva (sin abrir) usando la cadena de App.config.
        /// </summary>
        /// <returns>Conexión a la base de datos ControlAsistenciaDB.</returns>
        public static SqlConnection SubObtenerConexionG1()
        {
            ConnectionStringSettings objCadenaG1 = ConfigurationManager.ConnectionStrings["ControlAsistenciaDBG1"];
            string strCadenaG1 = objCadenaG1 != null ? objCadenaG1.ConnectionString : gStrCadenaPorDefectoG1;
            return new SqlConnection(strCadenaG1);
        }

        /// <summary>
        /// Ejecuta una consulta SELECT y devuelve los resultados en una tabla.
        /// </summary>
        /// <param name="strConsultaG1">Consulta SQL parametrizada.</param>
        /// <param name="arrParametrosG1">Parámetros de la consulta.</param>
        /// <returns>Tabla con los resultados.</returns>
        public static DataTable FunConsultarG1(string strConsultaG1, params SqlParameter[] arrParametrosG1)
        {
            using (SqlConnection objConexionG1 = SubObtenerConexionG1())
            using (SqlCommand objComandoG1 = new SqlCommand(strConsultaG1, objConexionG1))
            {
                if (arrParametrosG1 != null) objComandoG1.Parameters.AddRange(arrParametrosG1);
                DataTable dtResultadoG1 = new DataTable();
                using (SqlDataAdapter objAdaptadorG1 = new SqlDataAdapter(objComandoG1))
                {
                    objAdaptadorG1.Fill(dtResultadoG1);
                }
                return dtResultadoG1;
            }
        }

        /// <summary>
        /// Ejecuta un INSERT, UPDATE o DELETE.
        /// </summary>
        /// <param name="strConsultaG1">Instrucción SQL parametrizada.</param>
        /// <param name="arrParametrosG1">Parámetros de la instrucción.</param>
        /// <returns>Cantidad de filas afectadas.</returns>
        public static int FunEjecutarG1(string strConsultaG1, params SqlParameter[] arrParametrosG1)
        {
            using (SqlConnection objConexionG1 = SubObtenerConexionG1())
            using (SqlCommand objComandoG1 = new SqlCommand(strConsultaG1, objConexionG1))
            {
                if (arrParametrosG1 != null) objComandoG1.Parameters.AddRange(arrParametrosG1);
                objConexionG1.Open();
                return objComandoG1.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Ejecuta una consulta que devuelve un solo valor.
        /// </summary>
        /// <param name="strConsultaG1">Consulta SQL parametrizada.</param>
        /// <param name="arrParametrosG1">Parámetros de la consulta.</param>
        /// <returns>Primer valor de la primera fila, o null.</returns>
        public static object FunEscalarG1(string strConsultaG1, params SqlParameter[] arrParametrosG1)
        {
            using (SqlConnection objConexionG1 = SubObtenerConexionG1())
            using (SqlCommand objComandoG1 = new SqlCommand(strConsultaG1, objConexionG1))
            {
                if (arrParametrosG1 != null) objComandoG1.Parameters.AddRange(arrParametrosG1);
                objConexionG1.Open();
                object objValorG1 = objComandoG1.ExecuteScalar();
                return objValorG1 == System.DBNull.Value ? null : objValorG1;
            }
        }

        /// <summary>
        /// Crea un parámetro SQL; convierte null en DBNull.
        /// </summary>
        /// <param name="strNombreG1">Nombre del parámetro (con @).</param>
        /// <param name="objValorG1">Valor del parámetro.</param>
        /// <returns>Parámetro listo para usar.</returns>
        public static SqlParameter FunParametroG1(string strNombreG1, object objValorG1)
        {
            return new SqlParameter(strNombreG1, objValorG1 ?? System.DBNull.Value);
        }
    }
}
