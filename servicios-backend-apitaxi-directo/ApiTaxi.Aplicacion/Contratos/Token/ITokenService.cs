namespace ApiTaxi.Aplicacion.Contratos.Token
{
    public interface ITokenService
    {
        (string Token, int ExpiresIn) GenerarToken(string usuario, string usuarioId);
    }
}
