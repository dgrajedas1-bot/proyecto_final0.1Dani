using System;

namespace CapaEntidadesG1
{
    public class RegistroAsistenciaG1
    {
        public int IdRegistro { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime FechaHoraEntrada { get; set; }
        public DateTime? FechaHoraSalida { get; set; } // El '?' permite valores nulos
        public string Estado { get; set; }
        public decimal HorasExtras { get; set; }
    }
}