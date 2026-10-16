using System;
using CapaAccesoDatosG1;
using CapaEntidadesG1;

namespace CapaLogicaNegocioG1
{
    /// <summary>
    /// Reglas de negocio del inicio de sesión.
    /// </summary>
    public class UsuarioLogicaG1
    {
        private readonly UsuarioDatosG1 gObjDatosG1 = new UsuarioDatosG1();

        /// <summary>Valida las credenciales del usuario.</summary>
        /// <param name="strUsuarioG1">Nombre de usuario.</param>
        /// <param name="strContrasenaG1">Contraseña.</param>
        /// <returns>El usuario autenticado.</returns>
        public UsuarioG1 FunIniciarSesionG1(string strUsuarioG1, string strContrasenaG1)
        {
            string strUsuarioLimpioG1 = (strUsuarioG1 ?? "").Trim();
            if (strUsuarioLimpioG1.Length == 0) throw new ArgumentException("Ingrese su usuario.");
            if (string.IsNullOrEmpty(strContrasenaG1)) throw new ArgumentException("Ingrese su contraseña.");
            UsuarioG1 objUsuarioG1 = ErroresLogicaG1.FunEjecutarG1(() => gObjDatosG1.FunValidarG1(strUsuarioLimpioG1, strContrasenaG1));
            if (objUsuarioG1 == null) throw new ArgumentException("Usuario o contraseña incorrectos.");
            return objUsuarioG1;
        }
    }
}
