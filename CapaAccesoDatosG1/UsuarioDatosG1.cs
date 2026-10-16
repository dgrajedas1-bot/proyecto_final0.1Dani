using System.Data;
using CapaEntidadesG1;

namespace CapaAccesoDatosG1
{
    /// <summary>
    /// Acceso a datos de la tabla Usuarios (inicio de sesión).
    /// </summary>
    public class UsuarioDatosG1
    {
        /// <summary>Busca un usuario con el nombre y la contraseña indicados.</summary>
        /// <param name="strUsuarioG1">Nombre de usuario.</param>
        /// <param name="strContrasenaG1">Contraseña.</param>
        /// <returns>El usuario o null si las credenciales no coinciden.</returns>
        public UsuarioG1 FunValidarG1(string strUsuarioG1, string strContrasenaG1)
        {
            DataTable dtG1 = ConexionG1.FunConsultarG1(
                "SELECT IdUsuario, NombreUsuario, NombreCompleto FROM Usuarios " +
                "WHERE NombreUsuario = @usuario AND Contrasena = @contrasena COLLATE Latin1_General_CS_AS",
                ConexionG1.FunParametroG1("@usuario", strUsuarioG1), ConexionG1.FunParametroG1("@contrasena", strContrasenaG1));
            if (dtG1.Rows.Count == 0) return null;
            return new UsuarioG1
            {
                IdUsuarioG1 = (int)dtG1.Rows[0]["IdUsuario"],
                NombreUsuarioG1 = dtG1.Rows[0]["NombreUsuario"].ToString(),
                NombreCompletoG1 = dtG1.Rows[0]["NombreCompleto"].ToString()
            };
        }
    }
}
