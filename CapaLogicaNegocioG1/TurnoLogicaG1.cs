using System;
using System.Data;
using CapaAccesoDatosG1;
using CapaEntidadesG1;

namespace CapaLogicaNegocioG1
{
    /// <summary>
    /// Reglas de negocio para turnos y planificación de horarios (asignaciones).
    /// </summary>
    public class TurnoLogicaG1
    {
        private readonly TurnoDatosG1 gObjDatosG1 = new TurnoDatosG1();

        /// <summary>Lista los turnos.</summary>
        /// <returns>Tabla de turnos.</returns>
        public DataTable FunListarG1()
        {
            return ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunListarG1());
        }

        /// <summary>Valida y guarda un turno nuevo.</summary>
        /// <param name="objTurnoG1">Turno a guardar.</param>
        public void SubGuardarG1(TurnoG1 objTurnoG1)
        {
            SubValidarG1(objTurnoG1, 0);
            ErroresLogicaG1.SubEjecutarG1(() => gObjDatosG1.SubInsertarG1(objTurnoG1));
        }

        /// <summary>Valida y actualiza un turno.</summary>
        /// <param name="objTurnoG1">Turno con IdTurno.</param>
        public void SubActualizarG1(TurnoG1 objTurnoG1)
        {
            if (objTurnoG1 == null || objTurnoG1.IdTurno <= 0) throw new ArgumentException("Seleccione un turno de la lista para editarlo.");
            SubValidarG1(objTurnoG1, objTurnoG1.IdTurno);
            if (ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunActualizarG1(objTurnoG1)) == 0)
                throw new ArgumentException("El turno ya no existe.");
        }

        /// <summary>Elimina un turno si no tiene asignaciones.</summary>
        /// <param name="intIdG1">ID del turno.</param>
        public void SubEliminarG1(int intIdG1)
        {
            if (intIdG1 <= 0) throw new ArgumentException("Seleccione un turno de la lista.");
            int intAsignacionesG1 = ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunContarAsignacionesG1(intIdG1));
            if (intAsignacionesG1 > 0)
                throw new ArgumentException("No se puede eliminar: el turno tiene " + intAsignacionesG1 + " asignación(es).");
            if (ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunEliminarG1(intIdG1)) == 0)
                throw new ArgumentException("El turno ya no existe.");
        }

        /// <summary>Lista las asignaciones en un rango de fechas.</summary>
        /// <param name="dtmDesdeG1">Fecha inicial.</param>
        /// <param name="dtmHastaG1">Fecha final.</param>
        /// <returns>Tabla de asignaciones.</returns>
        public DataTable FunListarAsignacionesG1(DateTime dtmDesdeG1, DateTime dtmHastaG1)
        {
            if (dtmHastaG1.Date < dtmDesdeG1.Date) throw new ArgumentException("La fecha final no puede ser menor que la inicial.");
            return ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunListarAsignacionesG1(dtmDesdeG1, dtmHastaG1));
        }

        /// <summary>Asigna un turno a un empleado en una fecha (uno por día).</summary>
        /// <param name="objAsignacionG1">Asignación a guardar.</param>
        public void SubAsignarG1(AsignacionTurnoG1 objAsignacionG1)
        {
            if (objAsignacionG1 == null || objAsignacionG1.IdEmpleado <= 0) throw new ArgumentException("Seleccione un empleado.");
            if (objAsignacionG1.IdTurno <= 0) throw new ArgumentException("Seleccione un turno.");
            if (objAsignacionG1.FechaProgramada.Date < DateTime.Today.AddDays(-30))
                throw new ArgumentException("No se pueden asignar turnos con más de 30 días de antigüedad.");
            if (ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunExisteAsignacionG1(objAsignacionG1.IdEmpleado, objAsignacionG1.FechaProgramada)))
                throw new ArgumentException("El empleado ya tiene un turno asignado el " + objAsignacionG1.FechaProgramada.ToString("dd/MM/yyyy") + ".");
            ErroresLogicaG1.SubEjecutarG1(() => gObjDatosG1.SubInsertarAsignacionG1(objAsignacionG1));
        }

        /// <summary>Elimina una asignación.</summary>
        /// <param name="intIdAsignacionG1">ID de la asignación.</param>
        public void SubEliminarAsignacionG1(int intIdAsignacionG1)
        {
            if (intIdAsignacionG1 <= 0) throw new ArgumentException("Seleccione una asignación de la lista.");
            if (ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunEliminarAsignacionG1(intIdAsignacionG1)) == 0)
                throw new ArgumentException("La asignación ya no existe.");
        }

        /// <summary>Valida nombre, horas y tolerancia del turno.</summary>
        /// <param name="objTurnoG1">Turno a validar.</param>
        /// <param name="intIdExcluirG1">ID a excluir en la validación de nombre duplicado.</param>
        private void SubValidarG1(TurnoG1 objTurnoG1, int intIdExcluirG1)
        {
            if (objTurnoG1 == null) throw new ArgumentException("No hay datos del turno.");
            objTurnoG1.NombreTurno = (objTurnoG1.NombreTurno ?? "").Trim();
            if (objTurnoG1.NombreTurno.Length == 0) throw new ArgumentException("Ingrese el nombre del turno.");
            if (objTurnoG1.NombreTurno.Length > 50) throw new ArgumentException("El nombre del turno no puede tener más de 50 caracteres.");
            if (objTurnoG1.HoraEntrada == objTurnoG1.HoraSalida) throw new ArgumentException("La hora de entrada y la de salida no pueden ser iguales.");
            if (objTurnoG1.HorasJornadaG1 > 16) throw new ArgumentException("Un turno no puede durar más de 16 horas.");
            if (objTurnoG1.ToleranciaMinutos < 0 || objTurnoG1.ToleranciaMinutos > 120)
                throw new ArgumentException("La tolerancia debe estar entre 0 y 120 minutos.");
            string strNombreG1 = objTurnoG1.NombreTurno;
            if (ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunExisteNombreG1(strNombreG1, intIdExcluirG1)))
                throw new ArgumentException("Ya existe un turno con ese nombre.");
        }
    }
}
