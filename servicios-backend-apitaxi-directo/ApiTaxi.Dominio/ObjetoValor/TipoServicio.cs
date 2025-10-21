using ApiTaxi.Dominio.Excepciones;

namespace ApiTaxi.Dominio.ObjetoValor
{
    public record TipoServicio
    {
        public int Valor { get; }

        public TipoServicio(int id)
        {
            if (id is < 1 or > 3)
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(id)} es invalido");
            }
            Valor = id;
        }

        public override string ToString() => Valor switch
        {
            1 => "Normal(1)",
            2 => "Por horas(2)",
            3 => "Mensajería(3)",
            _ => "Desconocido"
        };
    }
}
