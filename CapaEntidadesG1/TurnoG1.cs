using System;

namespace CapaEntidadesG1
{
    /// <summary>
    /// Representa un turno de trabajo (tabla Turnos).
    /// </summary>
    public class TurnoG1
    {
        /// <summary>Identificador del turno.</summary>
        public int IdTurno { get; set; }
        /// <summary>Nombre del turno (Matutino, Vespertino, Nocturno...).</summary>
        public string NombreTurno { get; set; }
        /// <summary>Hora de entrada.</summary>
        public TimeSpan HoraEntrada { get; set; }
        /// <summary>Hora de salida.</summary>
        public TimeSpan HoraSalida { get; set; }
        /// <summary>Minutos de tolerancia antes de considerar tardanza.</summary>
        public int ToleranciaMinutos { get; set; }

        /// <summary>Indica si el turno termina al día siguiente (ej. 22:00 a 06:00).</summary>
        public bool EsNocturnoG1
        {
            get { return HoraSalida <= HoraEntrada; }
        }

        /// <summary>Duración del turno en horas (considera turnos nocturnos).</summary>
        public decimal HorasJornadaG1
        {
            get
            {
                TimeSpan tsDuracionG1 = HoraSalida - HoraEntrada;
                if (EsNocturnoG1) tsDuracionG1 = tsDuracionG1.Add(TimeSpan.FromHours(24));
                return (decimal)tsDuracionG1.TotalHours;
            }
        }
    }
}
