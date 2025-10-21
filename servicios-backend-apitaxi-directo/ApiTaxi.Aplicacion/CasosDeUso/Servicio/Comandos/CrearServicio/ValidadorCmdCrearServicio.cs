using FluentValidation;

namespace ApiTaxi.Aplicacion.CasosDeUso.Servicio.Comandos.CrearServicio
{
    public class ValidadorCmdCrearServicio : AbstractValidator<CmdCrearServicio>
    {
        public ValidadorCmdCrearServicio()
        {
            RuleFor(x => x.Ruc)
                .NotEmpty().WithMessage("El campo {PropertyName} es requerido");
            RuleFor(x => x.FechaServicio)
               .NotEmpty().WithMessage("El campo {PropertyName} es requerido");
            RuleFor(x => x.CodigoCentrocosto)
               .NotEmpty().WithMessage("El campo {PropertyName} es requerido");
            RuleFor(x => x.IdTipoServicio)
               .NotEmpty().WithMessage("El campo {PropertyName} es requerido");
            RuleFor(x => x.IdTipoPago)
               .NotEmpty().WithMessage("El campo {PropertyName} es requerido");
            RuleFor(x => x.TotalServicio)
               .NotEmpty().WithMessage("El campo {PropertyName} es requerido");
            RuleFor(x => x.DistanciaKilometro)
               .NotEmpty().WithMessage("El campo {PropertyName} es requerido");
            RuleFor(x => x.Observacion)
             .NotEmpty().WithMessage("El campo {PropertyName} es requerido");
            RuleFor(x => x.Destinos)
                .NotNull().WithMessage("La lista de Destinos es requerida")
                .Must(x => x.Any()).WithMessage("Debe incluir al menos un destino");
            RuleFor(x => x.Clientes)
           .NotNull().WithMessage("La lista de Clientes es requerida")
           .Must(x => x.Any()).WithMessage("Debe incluir al menos un cliente");
        }
    }
}
