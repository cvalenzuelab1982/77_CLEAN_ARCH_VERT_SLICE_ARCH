using ApiTaxi.Dominio.Excepciones;

namespace ApiTaxi.Dominio.ObjetoValor
{
    public record TipoPago
    {
        public int Valor { get; }

        public TipoPago(int id)
        {
            if (id is < 1 or > 3)
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(id)} es invalido");
            }
            Valor = id;
        }

        public override string ToString() => Valor switch
        {
            1 => "Crédito(1)",
            2 => "Efectivo(2)",
            3 => "Vale(3)",
            _ => "Desconocido"
        };
    }
}
