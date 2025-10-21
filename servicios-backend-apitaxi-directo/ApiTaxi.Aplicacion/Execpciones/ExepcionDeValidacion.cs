using FluentValidation.Results;

namespace ApiTaxi.Aplicacion.Execpciones
{
    public class ExepcionDeValidacion : Exception
    {
        public List<string> ErroresDeValidacion { get; set; } = [];

        public ExepcionDeValidacion(ValidationResult validationResult)
        {
            foreach (var errorDeValidacion in validationResult.Errors)
            {
                ErroresDeValidacion.Add(errorDeValidacion.ErrorMessage);
            }
        }
    }
}
