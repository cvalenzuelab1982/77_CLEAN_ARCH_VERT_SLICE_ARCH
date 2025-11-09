using AutoAlquila.Domain.Abstractions;

namespace AutoAlquila.Domain.Usuarios
{
    public static class UsuarioErrors
    {
        public static Error NotFound = new Error(
            "Usuario.NotFound",
            "No existe el usuario buscado por este id"
        );

        public static Error InvalidCredentials = new Error(
            "Usuario.InvalidCredentials",
            "Las credenciales son incorrectas"
        );
    }
}
