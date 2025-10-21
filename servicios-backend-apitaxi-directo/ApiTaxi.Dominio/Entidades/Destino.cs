using ApiTaxi.Dominio.ObjetoValor;

namespace ApiTaxi.Dominio.Entidades
{
    public class Destino
    {
        public int Id { get; private set; }
        public int ServicioId { get; private set; }
        public decimal LatitudOrigen { get; private set; }
        public decimal LongitudOrigen { get; private set; }
        public decimal LatitudDestino { get; private set; }
        public decimal LongitudDestino { get; private set; }
        public string DireccionOrigen { get; private set; } = null!;
        public int NumeroDireccionOrigen { get; private set; }
        public string DireccionDestino { get; private set; } = null!;
        public int NumeroDireccionDestino { get; private set; }
        public int Orden { get; private set; }
        public decimal DistanciaDestinoKilometro { get; private set; }
        public decimal Precio { get; private set; }
        public IntervaloTiempo? IntervaloTiempo { get; private set; }    
        public string ZonaOrigen { get; private set; } = null!;
        public string ZonaDestino { get; private set; } = null!;
        public bool Negociado { get; private set; }
        public Servicio? Servicio { get; set; }

        public Destino(int id, int servicioId, decimal latitudOrigen, decimal longitudOrigen, decimal latitudDestino, decimal longitudDestino, string direccionOrigen, int numeroDireccionOrigen, string direccionDestino, int numeroDireccionDestino, int orden, decimal distanciaDestinoKilometro, decimal precio, IntervaloTiempo intervaloTiempo, string zonaOrigen, string zonaDestino, bool negociado, Servicio? servicio)
        {
            Id = id;
            ServicioId = servicioId;
            LatitudOrigen = latitudOrigen;
            LongitudOrigen = longitudOrigen;
            LatitudDestino = latitudDestino;
            LongitudDestino = longitudDestino;
            DireccionOrigen = direccionOrigen;
            NumeroDireccionOrigen = numeroDireccionOrigen;
            DireccionDestino = direccionDestino;
            NumeroDireccionDestino = numeroDireccionDestino;
            Orden = orden;
            DistanciaDestinoKilometro = distanciaDestinoKilometro;
            Precio = precio;
            IntervaloTiempo = intervaloTiempo;
            ZonaOrigen = zonaOrigen;
            ZonaDestino = zonaDestino;
            Negociado = negociado;
            Servicio = servicio;
        }
    }
}
