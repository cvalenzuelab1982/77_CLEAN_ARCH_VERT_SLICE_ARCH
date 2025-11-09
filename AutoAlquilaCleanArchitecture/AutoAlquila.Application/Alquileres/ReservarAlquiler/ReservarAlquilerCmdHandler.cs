using AutoAlquila.Application.Abstractions.Clock;
using AutoAlquila.Application.Abstractions.Messaging;
using AutoAlquila.Application.Exceptions;
using AutoAlquila.Domain.Abstractions;
using AutoAlquila.Domain.Alquileres;
using AutoAlquila.Domain.Usuarios;
using AutoAlquila.Domain.Vehiculos;

namespace AutoAlquila.Application.Alquileres.ReservarAlquiler
{
    internal sealed class ReservarAlquilerCmdHandler : ICommandHandler<ReservarAlquilerCmd, Guid>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IVehiculoRepositorio _vehiculoRepositorio;
        private readonly IAlquilerRepository _alquilerRepository;
        private readonly PrecioService _precioService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public ReservarAlquilerCmdHandler(IUsuarioRepositorio usuarioRepositorio, IVehiculoRepositorio vehiculoRepositorio, IAlquilerRepository alquilerRepository,
        PrecioService precioService, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _vehiculoRepositorio = vehiculoRepositorio;
            _alquilerRepository = alquilerRepository;
            _precioService = precioService;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Result<Guid>> Handle(ReservarAlquilerCmd request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepositorio.GetByIdAsync(request.UsuarioId, cancellationToken);
            if (usuario is null)
            {
                return Result.Failure<Guid>(UsuarioErrors.NotFound);
            }

            var vehiculo = await _vehiculoRepositorio.GetByIdAsync(request.VehiculoId, cancellationToken);
            if (vehiculo is null)
            {
                return Result.Failure<Guid>(VehiculoErrors.NotFound);
            }

            var duracion = RangoFechas.Create(request.FechaInicio, request.FechaFin);
            if (await _alquilerRepository.IsOverlapingAsync(vehiculo, duracion, cancellationToken))
            {
                return Result.Failure<Guid>(AlquilerErrors.Overlap);
            }

            try
            {
                var alquiler = Alquiler.Reservar(vehiculo, usuario.Id, duracion, _dateTimeProvider.CurrentTime, _precioService);
                _alquilerRepository.Add(alquiler);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return alquiler.Id;
            }
            catch (ConcurrencyExpection)
            {
                return Result.Failure<Guid>(AlquilerErrors.Overlap);
            }
           
        }
    }
}
