namespace ApiTaxi.Aplicacion.CasosDeUso.Seguridad.Dtos
{
    public class TokenResponseDto
    {
        public bool Autenticado { get; set; }
        public string Token { get; set; } = null!;
        public string Mensaje { get; set; } = null!;
        public string TokenType { get; set; } = null!;
        public int ExpiresIn { get; set; }
    }
}
