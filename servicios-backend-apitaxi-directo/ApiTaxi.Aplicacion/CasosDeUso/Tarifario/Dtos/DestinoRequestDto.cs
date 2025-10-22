namespace ApiTaxi.Aplicacion.CasosDeUso.Tarifario.Dtos
{
    public class DestinoRequestDto
    {
        public decimal LatitudOrigen { get; set; }
        public decimal LongitudOrigen { get; set; }
        public decimal LatitudDestino { get; set; }
        public decimal LongitudDestino { get; set; }
        public string DireccionOrigen { get; set; } = null!;
        public int NumeroDireccionOrigen { get; set; }
        public string DireccionDestino { get; set; } = null!;
        public int NumeroDireccionDestino { get; set; }
        public int Orden { get; set; }
     
    }
}
