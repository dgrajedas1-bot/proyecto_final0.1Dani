using System;
using System.Data;
using CapaEntidadesG1;

namespace CapaAccesoDatosG1
{
    /// <summary>
    /// Acceso a datos de la tabla RegistroAsistencia: marcajes, reporte y conteos del panel de inicio.
    /// </summary>
    public class AsistenciaDatosG1
    {
        /// <summary>Obtiene la última entrada del empleado que todavía no tiene salida.</summary>
        /// <param name="intIdEmpleadoG1">ID del empleado.</param>
        /// <returns>El registro abierto o null.</returns>
        public RegistroAsistenciaG1 FunObtenerRegistroAbiertoG1(int intIdEmpleadoG1)
        {
            DataTable dtG1 = ConexionG1.FunConsultarG1(
                "SELECT TOP 1 * FROM RegistroAsistencia WHERE IdEmpleado = @emp AND FechaHoraSalida IS NULL ORDER BY FechaHoraEntrada DESC",
                ConexionG1.FunParametroG1("@emp", intIdEmpleadoG1));
            if (dtG1.Rows.Count == 0) return null;
            DataRow drG1 = dtG1.Rows[0];
            return new RegistroAsistenciaG1
            {
                IdRegistro = Convert.ToInt32(drG1["IdRegistro"]),
                IdEmpleado = Convert.ToInt32(drG1["IdEmpleado"]),
                FechaHoraEntrada = Convert.ToDateTime(drG1["FechaHoraEntrada"]),
                FechaHoraSalida = null,
                Estado = drG1["Estado"].ToString(),
                HorasExtras = drG1["HorasExtras"] == DBNull.Value ? 0 : Convert.ToDecimal(drG1["HorasExtras"]),
                MinutosRetardoG1 = Convert.ToInt32(drG1["MinutosRetardo"])
            };
        }

        /// <summary>Cuenta las entradas del empleado dentro de un rango de fecha y hora.</summary>
        /// <param name="intIdEmpleadoG1">ID del empleado.</param>
        /// <param name="dtmDesdeG1">Inicio del rango.</param>
        /// <param name="dtmHastaG1">Fin del rango.</param>
        /// <returns>Cantidad de entradas.</returns>
        public int FunContarIngresosEnRangoG1(int intIdEmpleadoG1, DateTime dtmDesdeG1, DateTime dtmHastaG1)
        {
            return Convert.ToInt32(ConexionG1.FunEscalarG1(
                "SELECT COUNT(*) FROM RegistroAsistencia WHERE IdEmpleado = @emp AND FechaHoraEntrada BETWEEN @desde AND @hasta",
                ConexionG1.FunParametroG1("@emp", intIdEmpleadoG1), ConexionG1.FunParametroG1("@desde", dtmDesdeG1),
                ConexionG1.FunParametroG1("@hasta", dtmHastaG1)));
        }

        /// <summary>Guarda una marcación de entrada.</summary>
        /// <param name="objRegistroG1">Registro con empleado, hora, estado y retardo.</param>
        public void SubInsertarIngresoG1(RegistroAsistenciaG1 objRegistroG1)
        {
            ConexionG1.FunEjecutarG1(
                "INSERT INTO RegistroAsistencia (IdEmpleado, FechaHoraEntrada, Estado, MinutosRetardo, HorasExtras) " +
                "VALUES (@emp, @entrada, @estado, @retardo, 0)",
                ConexionG1.FunParametroG1("@emp", objRegistroG1.IdEmpleado),
                ConexionG1.FunParametroG1("@entrada", objRegistroG1.FechaHoraEntrada),
                ConexionG1.FunParametroG1("@estado", objRegistroG1.Estado),
                ConexionG1.FunParametroG1("@retardo", objRegistroG1.MinutosRetardoG1));
        }

        /// <summary>Guarda la salida y las horas extras de un registro abierto.</summary>
        /// <param name="intIdRegistroG1">ID del registro.</param>
        /// <param name="dtmSalidaG1">Fecha y hora de salida.</param>
        /// <param name="decHorasExtrasG1">Horas extras calculadas.</param>
        /// <returns>Filas afectadas.</returns>
        public int FunRegistrarSalidaG1(int intIdRegistroG1, DateTime dtmSalidaG1, decimal decHorasExtrasG1)
        {
            return ConexionG1.FunEjecutarG1(
                "UPDATE RegistroAsistencia SET FechaHoraSalida = @salida, HorasExtras = @extras WHERE IdRegistro = @id AND FechaHoraSalida IS NULL",
                ConexionG1.FunParametroG1("@salida", dtmSalidaG1), ConexionG1.FunParametroG1("@extras", decHorasExtrasG1),
                ConexionG1.FunParametroG1("@id", intIdRegistroG1));
        }

        /// <summary>
        /// Reporte de asistencia por periodo. Incluye como "Ausente" los turnos asignados
        /// que ya terminaron y no tienen marcación.
        /// </summary>
        /// <param name="dtmDesdeG1">Fecha inicial.</param>
        /// <param name="dtmHastaG1">Fecha final.</param>
        /// <returns>Tabla del reporte (incluye SalarioBase para calcular el pago de extras).</returns>
        public DataTable FunReporteG1(DateTime dtmDesdeG1, DateTime dtmHastaG1)
        {
            return ConexionG1.FunConsultarG1(
                "SELECT e.CodigoCarnet AS Codigo, e.Nombres + ' ' + e.Apellidos AS Empleado, CAST(r.FechaHoraEntrada AS DATE) AS Fecha, " +
                "CONVERT(VARCHAR(5), r.FechaHoraEntrada, 108) AS Entrada, CONVERT(VARCHAR(5), r.FechaHoraSalida, 108) AS Salida, " +
                "r.Estado, r.MinutosRetardo, " +
                "CAST(ISNULL(DATEDIFF(MINUTE, r.FechaHoraEntrada, r.FechaHoraSalida), 0) / 60.0 AS DECIMAL(6,2)) AS HorasTrabajadas, " +
                "ISNULL(r.HorasExtras, 0) AS HorasExtras, e.SalarioBase " +
                "FROM RegistroAsistencia r INNER JOIN Empleados e ON e.IdEmpleado = r.IdEmpleado " +
                "WHERE CAST(r.FechaHoraEntrada AS DATE) BETWEEN @desde AND @hasta " +
                "UNION ALL " +
                "SELECT e.CodigoCarnet, e.Nombres + ' ' + e.Apellidos, a.FechaProgramada, NULL, NULL, 'Ausente', 0, CAST(0 AS DECIMAL(6,2)), 0, e.SalarioBase " +
                "FROM AsignacionTurnos a INNER JOIN Empleados e ON e.IdEmpleado = a.IdEmpleado INNER JOIN Turnos t ON t.IdTurno = a.IdTurno " +
                "WHERE a.FechaProgramada BETWEEN @desde AND @hasta " +
                "AND DATEADD(DAY, CASE WHEN t.HoraSalida <= t.HoraEntrada THEN 1 ELSE 0 END, CAST(a.FechaProgramada AS DATETIME) + CAST(t.HoraSalida AS DATETIME)) < GETDATE() " +
                "AND NOT EXISTS (SELECT 1 FROM RegistroAsistencia r2 WHERE r2.IdEmpleado = a.IdEmpleado " +
                "AND CAST(r2.FechaHoraEntrada AS DATE) = a.FechaProgramada) " +
                "ORDER BY Fecha, Codigo",
                ConexionG1.FunParametroG1("@desde", dtmDesdeG1.Date), ConexionG1.FunParametroG1("@hasta", dtmHastaG1.Date));
        }

        /// <summary>Cuenta los empleados activos.</summary>
        /// <returns>Total de empleados activos.</returns>
        public int FunContarEmpleadosActivosG1()
        {
            return Convert.ToInt32(ConexionG1.FunEscalarG1("SELECT COUNT(*) FROM Empleados WHERE Activo = 1"));
        }

        /// <summary>Cuenta los empleados distintos que marcaron entrada hoy.</summary>
        /// <returns>Presentes hoy (incluye tardes).</returns>
        public int FunContarPresentesHoyG1()
        {
            return Convert.ToInt32(ConexionG1.FunEscalarG1(
                "SELECT COUNT(DISTINCT IdEmpleado) FROM RegistroAsistencia WHERE CAST(FechaHoraEntrada AS DATE) = CAST(GETDATE() AS DATE)"));
        }

        /// <summary>Cuenta las tardanzas de hoy.</summary>
        /// <returns>Tardanzas hoy.</returns>
        public int FunContarTardanzasHoyG1()
        {
            return Convert.ToInt32(ConexionG1.FunEscalarG1(
                "SELECT COUNT(*) FROM RegistroAsistencia WHERE Estado = 'Tarde' AND CAST(FechaHoraEntrada AS DATE) = CAST(GETDATE() AS DATE)"));
        }

        /// <summary>Cuenta los empleados que tienen turno asignado hoy.</summary>
        /// <returns>Asignados hoy.</returns>
        public int FunContarAsignadosHoyG1()
        {
            return Convert.ToInt32(ConexionG1.FunEscalarG1(
                "SELECT COUNT(*) FROM AsignacionTurnos WHERE FechaProgramada = CAST(GETDATE() AS DATE)"));
        }

        /// <summary>Últimas 10 marcaciones del día.</summary>
        /// <returns>Tabla con código, empleado, hora y estado.</returns>
        public DataTable FunUltimasAsistenciasHoyG1()
        {
            return ConexionG1.FunConsultarG1(
                "SELECT TOP 10 e.CodigoCarnet AS Codigo, e.Nombres + ' ' + e.Apellidos AS Empleado, " +
                "CONVERT(VARCHAR(5), r.FechaHoraEntrada, 108) AS Entrada, CONVERT(VARCHAR(5), r.FechaHoraSalida, 108) AS Salida, r.Estado " +
                "FROM RegistroAsistencia r INNER JOIN Empleados e ON e.IdEmpleado = r.IdEmpleado " +
                "WHERE CAST(r.FechaHoraEntrada AS DATE) = CAST(GETDATE() AS DATE) ORDER BY r.FechaHoraEntrada DESC");
        }

        /// <summary>Tardanzas del día con los minutos de retardo.</summary>
        /// <returns>Tabla con código, empleado, hora y minutos de retardo.</returns>
        public DataTable FunAlertasTardanzaHoyG1()
        {
            return ConexionG1.FunConsultarG1(
                "SELECT e.CodigoCarnet AS Codigo, e.Nombres + ' ' + e.Apellidos AS Empleado, " +
                "CONVERT(VARCHAR(5), r.FechaHoraEntrada, 108) AS Entrada, r.MinutosRetardo AS MinRetardo " +
                "FROM RegistroAsistencia r INNER JOIN Empleados e ON e.IdEmpleado = r.IdEmpleado " +
                "WHERE r.Estado = 'Tarde' AND CAST(r.FechaHoraEntrada AS DATE) = CAST(GETDATE() AS DATE) ORDER BY r.MinutosRetardo DESC");
        }
    }
}
