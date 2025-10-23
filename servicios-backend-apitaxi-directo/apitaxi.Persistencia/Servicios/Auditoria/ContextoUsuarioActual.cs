using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ApiTaxi.Persistencia.Servicios.Auditoria
{
    public class ContextoUsuarioActual : IContextoUsuarioActual
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContextoUsuarioActual(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? IdUsuario =>
            _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        public string? NombreUsuario =>
            _httpContextAccessor.HttpContext?.User?.Identity?.Name;
    }
}
