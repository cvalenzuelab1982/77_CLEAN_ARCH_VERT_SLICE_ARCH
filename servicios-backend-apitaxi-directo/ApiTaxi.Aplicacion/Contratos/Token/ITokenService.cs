namespace ApiTaxi.Aplicacion.Contratos.Token
{
    public interface ITokenService
    {
        string GenerarToken(string usuario, string usuarioId);
    }
}
