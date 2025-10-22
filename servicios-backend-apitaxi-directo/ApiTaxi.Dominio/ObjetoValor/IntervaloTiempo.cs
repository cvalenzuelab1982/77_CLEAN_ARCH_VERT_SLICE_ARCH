using ApiTaxi.Dominio.Excepciones;

namespace ApiTaxi.Dominio.ObjetoValor
{
    public record IntervaloTiempo
    {
        public string Inicio { get; } = null!;
        public string Fin { get; } = null!;

        private const string Formato = "yyyy-MM-dd HH:mm:ss";

        public IntervaloTiempo(string? inicio, string? fin)
        {
            // Si ambos son nulos o vacíos, simplemente no hay intervalo
            if (string.IsNullOrWhiteSpace(inicio) && string.IsNullOrWhiteSpace(fin))
            {
                Inicio = null!;
                Fin = null!;
                return;
            }

            // Si uno solo tiene valor, validar formato
            DateTime? fechaInicio = null;
            DateTime? fechaFin = null;

            if (!string.IsNullOrWhiteSpace(inicio))
            {
                if (!DateTime.TryParseExact(inicio, Formato, null, System.Globalization.DateTimeStyles.None, out var fi))
                    throw new ExcepcionDeReglaDeNegocio($"La fecha de inicio '{inicio}' no tiene un formato válido.");
                fechaInicio = fi;
            }

            if (!string.IsNullOrWhiteSpace(fin))
            {
                if (!DateTime.TryParseExact(fin, Formato, null, System.Globalization.DateTimeStyles.None, out var ff))
                    throw new ExcepcionDeReglaDeNegocio($"La fecha de fin '{fin}' no tiene un formato válido.");
                fechaFin = ff;
            }



            // Validar lógica: si ambas existen, inicio ≤ fin
            if (fechaInicio.HasValue && fechaFin.HasValue && fechaInicio > fechaFin)
                throw new ExcepcionDeReglaDeNegocio("La fecha de inicio no puede ser posterior a la fecha de fin.");

            Inicio = inicio!;
            Fin = fin!;
        }
    }
}
