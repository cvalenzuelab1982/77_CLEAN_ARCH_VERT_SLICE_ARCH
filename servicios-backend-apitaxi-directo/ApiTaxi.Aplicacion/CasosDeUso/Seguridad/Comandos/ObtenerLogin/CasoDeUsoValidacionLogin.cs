using ApiTaxi.Aplicacion.CasosDeUso.Seguridad.Dtos;
using ApiTaxi.Aplicacion.Contratos.Repositorios;
using ApiTaxi.Aplicacion.Contratos.Token;
using ApiTaxi.Aplicacion.Utilidades.Mediador;

namespace ApiTaxi.Aplicacion.CasosDeUso.Seguridad.Comandos.ObtenerLogin
{
    public class CasoDeUsoValidacionLogin : IRequestHandler<CmdValidacionLogin, TokenResponseDto>
    {
        private readonly IRepositorioSeguridad _repositorio;
        private readonly ITokenService _tokenService;

        public CasoDeUsoValidacionLogin(IRepositorioSeguridad repositorio, ITokenService tokenService)
        {
            _repositorio = repositorio;
            _tokenService = tokenService;
        }

        public async Task<TokenResponseDto> Handle(CmdValidacionLogin request)
        {
            var estado = await _repositorio.Autenticar(request);
            if (estado == "VALID")
            {
                string token = _tokenService.GenerarToken(request.Usuario);
                return new TokenResponseDto
                {
                    Autenticado = true,
                    Token = token,
                    Mensaje = "Autenticación exitosa."
                };
            }

            return new TokenResponseDto
            {
                Autenticado = false,
                Mensaje = "Usuario o contraseña incorrectos."
            };

        }
    }
}
