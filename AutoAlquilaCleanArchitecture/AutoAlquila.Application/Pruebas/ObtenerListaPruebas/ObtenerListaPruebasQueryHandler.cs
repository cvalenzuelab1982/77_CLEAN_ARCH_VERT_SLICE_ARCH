using AutoAlquila.Domain.Pruebas;
using MediatR;

namespace AutoAlquila.Application.Pruebas.ObtenerListaPruebas
{
    public sealed class ObtenerListaPruebasQueryHandler : IRequestHandler<ObtenerListaPruebasQuery, List<PruebaResponse>>
    {
        private readonly IPruebaRepository _repository;

        public ObtenerListaPruebasQueryHandler(IPruebaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PruebaResponse>> Handle(ObtenerListaPruebasQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.ObtenerListaPruebas(cancellationToken);
            return list.Select(x => new PruebaResponse(x.Id, x.Nombre)).ToList();
        }
    }
}
