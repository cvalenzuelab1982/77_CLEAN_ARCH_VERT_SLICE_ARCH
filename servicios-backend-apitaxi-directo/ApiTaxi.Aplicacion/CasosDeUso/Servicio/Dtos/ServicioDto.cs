namespace ApiTaxi.Aplicacion.CasosDeUso.Servicio.Dtos
{
    public class ServicioDto
    {
        public int IdServicio { get; set; }
        public int IdEstado { get; set; }
        public int IdConductor { get; set; }
        public string Mensaje { get; set; } = null!;
    }
}
