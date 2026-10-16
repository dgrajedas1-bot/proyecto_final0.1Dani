using System;

namespace CapaEntidadesG1
{
    public class TurnoG1
    {
        public int IdTurno { get; set; }
        public string NombreTurno { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public int ToleranciaMinutos { get; set; }
    }
}