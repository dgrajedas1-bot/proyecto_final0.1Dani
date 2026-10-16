namespace CapaEntidadesG1
{
    /// <summary>
    /// Resultado que la capa lógica devuelve a la pantalla después de un marcaje.
    /// </summary>
    public class ResultadoMarcajeG1
    {
        /// <summary>Indica si el marcaje se guardó.</summary>
        public bool ExitosoG1 { get; set; }
        /// <summary>Mensaje para mostrar al usuario.</summary>
        public string MensajeG1 { get; set; }
        /// <summary>Estado resultante (Presente, Tarde...).</summary>
        public string EstadoG1 { get; set; }
        /// <summary>Minutos de retardo calculados.</summary>
        public int MinutosRetardoG1 { get; set; }
        /// <summary>Horas extras calculadas (solo en la salida).</summary>
        public decimal HorasExtrasG1 { get; set; }
        /// <summary>Pago de horas extras (solo en la salida).</summary>
        public decimal PagoHorasExtrasG1 { get; set; }
    }
}
