using System;

namespace CapaEntidadesG1
{
    /// <summary>
    /// Representa la asignación de un turno a un empleado en una fecha (tabla AsignacionTurnos).
    /// </summary>
    public class AsignacionTurnoG1
    {
        /// <summary>Identificador de la asignación.</summary>
        public int IdAsignacion { get; set; }
        /// <summary>Empleado al que se le asigna el turno.</summary>
        public int IdEmpleado { get; set; }
        /// <summary>Turno asignado.</summary>
        public int IdTurno { get; set; }
        /// <summary>Fecha en la que el empleado trabaja ese turno.</summary>
        public DateTime FechaProgramada { get; set; }
    }
}
