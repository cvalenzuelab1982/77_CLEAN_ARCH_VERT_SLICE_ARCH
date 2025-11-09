using AutoAlquila.Application.Abstractions.Email;
using AutoAlquila.Domain.Alquileres;
using AutoAlquila.Domain.Alquileres.Events;
using AutoAlquila.Domain.Usuarios;
using MediatR;

namespace AutoAlquila.Application.Alquileres.ReservarAlquiler
{
    internal sealed class ReservarAlquilerDomainEventHandler : INotificationHandler<AlquilerReservaDomainEvent>
    {
        private readonly IAlquilerRepository _alquilerRepository;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IEmailService _emailService;

        public ReservarAlquilerDomainEventHandler(IAlquilerRepository alquilerRepository, IUsuarioRepositorio usuarioRepositorio, IEmailService emailService)
        {
            _alquilerRepository = alquilerRepository;
            _usuarioRepositorio = usuarioRepositorio;
            _emailService = emailService;
        }

        public async Task Handle(AlquilerReservaDomainEvent notification, CancellationToken cancellationToken)
        {
            var alquiler = await _alquilerRepository.GetByIdAsync(notification.AlquilerId, cancellationToken);
            if (alquiler is null) 
            { 
                return;
            }

            var usuario = await _usuarioRepositorio.GetByIdAsync(alquiler.UsuarioId, cancellationToken);
            if (usuario is null) 
            {
                return;
            }

            await _emailService.SendEmailAsync(usuario.Email!, "Alquile reservado", "Tienes que confirmar esta reserva de lo contrario se va a perder");
        }
    }
}
