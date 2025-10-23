namespace ApiTaxi.Persistencia.Servicios.Auditoria
{
    public interface IContextoUsuarioActual
    {
        string? IdUsuario { get; }
        string? NombreUsuario { get; }
    }
}
