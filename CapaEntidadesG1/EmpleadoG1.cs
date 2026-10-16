namespace CapaEntidadesG1
{
    public class EmpleadoG1
    {
        public int IdEmpleado { get; set; }
        public string CodigoCarnet { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int IdDepartamento { get; set; }
        public string Puesto { get; set; }       
        public decimal SalarioBase { get; set; }  
        public bool Activo { get; set; }
    }
}