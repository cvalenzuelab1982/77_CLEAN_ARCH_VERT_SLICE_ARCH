using ApiTaxi.Dominio.Excepciones;

namespace ApiTaxi.Dominio.ObjetoValor
{
    public record TipoDocumento
    {
        public int Valor { get; }

        public TipoDocumento(int id)
        {
            if (id is < 1 or > 4)
            {
                throw new ExcepcionDeReglaDeNegocio($"El {nameof(id)} es invalido");
            }
            Valor = id;
        }

        public override string ToString() => Valor switch
        {
            1 => "DNI(1)",
            2 => "Carnet Extranjeria(2)",
            3 => "RUC(3)",
            4 => "Pasaporte(4)",
            _ => "Desconocido"
        };
    }
}
