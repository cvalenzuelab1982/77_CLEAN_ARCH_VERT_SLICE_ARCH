using FluentValidation;

namespace AutoAlquila.Application.Alquileres.ReservarAlquiler
{
    public class ReservarAlquilerCmdValidator : AbstractValidator<ReservarAlquilerCmd>
    {
        public ReservarAlquilerCmdValidator()
        {
            RuleFor(x => x.UsuarioId).NotEmpty();
            RuleFor(x => x.VehiculoId).NotEmpty();
            RuleFor(x => x.FechaInicio).LessThan(x => x.FechaFin);
        }
    }
}
