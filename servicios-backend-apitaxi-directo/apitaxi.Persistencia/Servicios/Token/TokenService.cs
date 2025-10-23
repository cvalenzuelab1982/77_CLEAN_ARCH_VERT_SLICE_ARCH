using ApiTaxi.Aplicacion.Contratos.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiTaxi.Persistencia.Servicios.Token
{
    public class TokenService : ITokenService
    {
        private readonly string _jwtKey;
        private readonly string _jwtIssuer;

        public TokenService(IConfiguration configuration)
        {
            _jwtKey = configuration["Jwt:Key"] ?? throw new ArgumentNullException("Jwt:key");
            _jwtIssuer = configuration["Jwt:Issuer"] ?? "ApiTaxi";
        }

        public string GenerarToken(string usuario, string usuarioId)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario),
                new Claim(ClaimTypes.NameIdentifier, usuarioId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtIssuer,
                audience: _jwtIssuer,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
