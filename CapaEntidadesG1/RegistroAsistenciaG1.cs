using System;

namespace CapaEntidadesG1
{
    /// <summary>
    /// Representa una marcación de entrada/salida (tabla RegistroAsistencia).
    /// </summary>
    public class RegistroAsistenciaG1
    {
        /// <summary>Identificador del registro.</summary>
        public int IdRegistro { get; set; }
        /// <summary>Empleado que marcó.</summary>
        public int IdEmpleado { get; set; }
        /// <summary>Fecha y hora de entrada.</summary>
        public DateTime FechaHoraEntrada { get; set; }
        /// <summary>Fecha y hora de salida; nula mientras no marque salida.</summary>
        public DateTime? FechaHoraSalida { get; set; }
        /// <summary>Estado: Presente, Tarde, Ausente o Justificado.</summary>
        public string Estado { get; set; }
        /// <summary>Horas extras calculadas al marcar la salida.</summary>
        public decimal HorasExtras { get; set; }
        /// <summary>Minutos de retardo respecto a la hora de entrada del turno.</summary>
        public int MinutosRetardoG1 { get; set; }
    }
}
