using CapaEntidadesG1;

namespace CapaPresentacionG1
{
    /// <summary>
    /// Guarda el usuario que inició sesión para que los formularios lo consulten.
    /// </summary>
    public static class SesionG1
    {
        /// <summary>Usuario autenticado actualmente (null si no hay sesión).</summary>
        public static UsuarioG1 UsuarioActualG1 { get; set; }
    }
}
