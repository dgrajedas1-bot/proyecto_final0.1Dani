namespace CapaEntidadesG1
{
    /// <summary>
    /// Representa a un empleado de la empresa (tabla Empleados).
    /// </summary>
    public class EmpleadoG1
    {
        /// <summary>Identificador interno del empleado.</summary>
        public int IdEmpleado { get; set; }
        /// <summary>Código de carné de 3 dígitos (001, 002, ...).</summary>
        public string CodigoCarnet { get; set; }
        /// <summary>Nombres del empleado.</summary>
        public string Nombres { get; set; }
        /// <summary>Apellidos del empleado.</summary>
        public string Apellidos { get; set; }
        /// <summary>Departamento al que pertenece.</summary>
        public int IdDepartamento { get; set; }
        /// <summary>Puesto que ocupa.</summary>
        public string Puesto { get; set; }
        /// <summary>Salario base mensual en quetzales.</summary>
        public decimal SalarioBase { get; set; }
        /// <summary>Indica si el empleado está activo.</summary>
        public bool Activo { get; set; }
    }
}
