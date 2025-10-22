namespace ApiTaxi.Aplicacion.Contratos.Persistencia
{
    public interface IUnitOfWork
    {
        Task Persistir();
        Task Reversar();
    }
}
