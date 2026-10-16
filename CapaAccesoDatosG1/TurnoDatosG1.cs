using System;
using System.Data;
using CapaEntidadesG1;

namespace CapaAccesoDatosG1
{
    /// <summary>
    /// Acceso a datos de las tablas Turnos y AsignacionTurnos.
    /// </summary>
    public class TurnoDatosG1
    {
        /// <summary>Lista todos los turnos.</summary>
        /// <returns>Tabla de turnos.</returns>
        public DataTable FunListarG1()
        {
            return ConexionG1.FunConsultarG1(
                "SELECT IdTurno, NombreTurno, HoraEntrada, HoraSalida, ToleranciaMinutos FROM Turnos ORDER BY IdTurno");
        }

        /// <summary>Indica si ya existe un turno con ese nombre (excluyendo un ID).</summary>
        /// <param name="strNombreG1">Nombre a validar.</param>
        /// <param name="intIdExcluirG1">ID que no se toma en cuenta.</param>
        /// <returns>True si existe.</returns>
        public bool FunExisteNombreG1(string strNombreG1, int intIdExcluirG1)
        {
            return Convert.ToInt32(ConexionG1.FunEscalarG1(
                "SELECT COUNT(*) FROM Turnos WHERE NombreTurno = @nombre AND IdTurno <> @id",
                ConexionG1.FunParametroG1("@nombre", strNombreG1), ConexionG1.FunParametroG1("@id", intIdExcluirG1))) > 0;
        }

        /// <summary>Inserta un turno.</summary>
        /// <param name="objTurnoG1">Turno a guardar.</param>
        public void SubInsertarG1(TurnoG1 objTurnoG1)
        {
            ConexionG1.FunEjecutarG1(
                "INSERT INTO Turnos (NombreTurno, HoraEntrada, HoraSalida, ToleranciaMinutos) VALUES (@nombre, @entrada, @salida, @tolerancia)",
                FunParametrosG1(objTurnoG1));
        }

        /// <summary>Actualiza un turno.</summary>
        /// <param name="objTurnoG1">Turno con datos nuevos.</param>
        /// <returns>Filas afectadas.</returns>
        public int FunActualizarG1(TurnoG1 objTurnoG1)
        {
            return ConexionG1.FunEjecutarG1(
                "UPDATE Turnos SET NombreTurno = @nombre, HoraEntrada = @entrada, HoraSalida = @salida, ToleranciaMinutos = @tolerancia WHERE IdTurno = @id",
                FunParametrosG1(objTurnoG1));
        }

        /// <summary>Cuenta las asignaciones que usan un turno.</summary>
        /// <param name="intIdG1">ID del turno.</param>
        /// <returns>Cantidad de asignaciones.</returns>
        public int FunContarAsignacionesG1(int intIdG1)
        {
            return Convert.ToInt32(ConexionG1.FunEscalarG1("SELECT COUNT(*) FROM AsignacionTurnos WHERE IdTurno = @id",
                ConexionG1.FunParametroG1("@id", intIdG1)));
        }

        /// <summary>Elimina un turno.</summary>
        /// <param name="intIdG1">ID del turno.</param>
        /// <returns>Filas afectadas.</returns>
        public int FunEliminarG1(int intIdG1)
        {
            return ConexionG1.FunEjecutarG1("DELETE FROM Turnos WHERE IdTurno = @id", ConexionG1.FunParametroG1("@id", intIdG1));
        }

        /// <summary>Lista las asignaciones de turnos en un rango de fechas.</summary>
        /// <param name="dtmDesdeG1">Fecha inicial.</param>
        /// <param name="dtmHastaG1">Fecha final.</param>
        /// <returns>Tabla de asignaciones con empleado y turno.</returns>
        public DataTable FunListarAsignacionesG1(DateTime dtmDesdeG1, DateTime dtmHastaG1)
        {
            return ConexionG1.FunConsultarG1(
                "SELECT a.IdAsignacion, a.FechaProgramada AS Fecha, e.CodigoCarnet AS Codigo, " +
                "e.Nombres + ' ' + e.Apellidos AS Empleado, t.NombreTurno AS Turno, t.HoraEntrada, t.HoraSalida " +
                "FROM AsignacionTurnos a INNER JOIN Empleados e ON e.IdEmpleado = a.IdEmpleado " +
                "INNER JOIN Turnos t ON t.IdTurno = a.IdTurno " +
                "WHERE a.FechaProgramada BETWEEN @desde AND @hasta ORDER BY a.FechaProgramada, e.CodigoCarnet",
                ConexionG1.FunParametroG1("@desde", dtmDesdeG1.Date), ConexionG1.FunParametroG1("@hasta", dtmHastaG1.Date));
        }

        /// <summary>Indica si el empleado ya tiene turno en esa fecha.</summary>
        /// <param name="intIdEmpleadoG1">ID del empleado.</param>
        /// <param name="dtmFechaG1">Fecha programada.</param>
        /// <returns>True si ya tiene asignación.</returns>
        public bool FunExisteAsignacionG1(int intIdEmpleadoG1, DateTime dtmFechaG1)
        {
            return Convert.ToInt32(ConexionG1.FunEscalarG1(
                "SELECT COUNT(*) FROM AsignacionTurnos WHERE IdEmpleado = @emp AND FechaProgramada = @fecha",
                ConexionG1.FunParametroG1("@emp", intIdEmpleadoG1), ConexionG1.FunParametroG1("@fecha", dtmFechaG1.Date))) > 0;
        }

        /// <summary>Inserta una asignación de turno.</summary>
        /// <param name="objAsignacionG1">Asignación a guardar.</param>
        public void SubInsertarAsignacionG1(AsignacionTurnoG1 objAsignacionG1)
        {
            ConexionG1.FunEjecutarG1(
                "INSERT INTO AsignacionTurnos (IdEmpleado, IdTurno, FechaProgramada) VALUES (@emp, @turno, @fecha)",
                ConexionG1.FunParametroG1("@emp", objAsignacionG1.IdEmpleado),
                ConexionG1.FunParametroG1("@turno", objAsignacionG1.IdTurno),
                ConexionG1.FunParametroG1("@fecha", objAsignacionG1.FechaProgramada.Date));
        }

        /// <summary>Elimina una asignación de turno.</summary>
        /// <param name="intIdAsignacionG1">ID de la asignación.</param>
        /// <returns>Filas afectadas.</returns>
        public int FunEliminarAsignacionG1(int intIdAsignacionG1)
        {
            return ConexionG1.FunEjecutarG1("DELETE FROM AsignacionTurnos WHERE IdAsignacion = @id",
                ConexionG1.FunParametroG1("@id", intIdAsignacionG1));
        }

        /// <summary>Obtiene el turno asignado a un empleado en una fecha.</summary>
        /// <param name="intIdEmpleadoG1">ID del empleado.</param>
        /// <param name="dtmFechaG1">Fecha programada.</param>
        /// <returns>El turno o null si no tiene.</returns>
        public TurnoG1 FunObtenerTurnoAsignadoG1(int intIdEmpleadoG1, DateTime dtmFechaG1)
        {
            DataTable dtG1 = ConexionG1.FunConsultarG1(
                "SELECT t.IdTurno, t.NombreTurno, t.HoraEntrada, t.HoraSalida, t.ToleranciaMinutos FROM AsignacionTurnos a " +
                "INNER JOIN Turnos t ON t.IdTurno = a.IdTurno WHERE a.IdEmpleado = @emp AND a.FechaProgramada = @fecha",
                ConexionG1.FunParametroG1("@emp", intIdEmpleadoG1), ConexionG1.FunParametroG1("@fecha", dtmFechaG1.Date));
            if (dtG1.Rows.Count == 0) return null;
            DataRow drG1 = dtG1.Rows[0];
            return new TurnoG1
            {
                IdTurno = Convert.ToInt32(drG1["IdTurno"]),
                NombreTurno = drG1["NombreTurno"].ToString(),
                HoraEntrada = (TimeSpan)drG1["HoraEntrada"],
                HoraSalida = (TimeSpan)drG1["HoraSalida"],
                ToleranciaMinutos = Convert.ToInt32(drG1["ToleranciaMinutos"])
            };
        }

        /// <summary>Arma los parámetros de un turno.</summary>
        /// <param name="objTurnoG1">Turno de origen.</param>
        /// <returns>Arreglo de parámetros.</returns>
        private System.Data.SqlClient.SqlParameter[] FunParametrosG1(TurnoG1 objTurnoG1)
        {
            return new[]
            {
                ConexionG1.FunParametroG1("@id", objTurnoG1.IdTurno),
                ConexionG1.FunParametroG1("@nombre", objTurnoG1.NombreTurno),
                ConexionG1.FunParametroG1("@entrada", objTurnoG1.HoraEntrada),
                ConexionG1.FunParametroG1("@salida", objTurnoG1.HoraSalida),
                ConexionG1.FunParametroG1("@tolerancia", objTurnoG1.ToleranciaMinutos)
            };
        }
    }
}
