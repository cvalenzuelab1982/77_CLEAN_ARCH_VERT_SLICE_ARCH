using MediatR;

namespace AutoAlquila.Application.Pruebas.ObtenerListaPruebas
{
    public sealed record ObtenerListaPruebasQuery() : IRequest<List<PruebaResponse>>;
}
