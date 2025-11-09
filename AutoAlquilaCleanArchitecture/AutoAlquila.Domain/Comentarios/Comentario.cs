using AutoAlquila.Domain.Abstractions;
using AutoAlquila.Domain.Alquileres;
using AutoAlquila.Domain.Comentarios.Events;

namespace AutoAlquila.Domain.Comentarios
{
    public sealed class Comentario : Entity
    {
        public Guid VehiculoId { get; private set; }
        public Guid AlquilerId { get; private set; }
        public Guid UsuarioId { get; private set; }
        public Rating Rating { get; private set; }
        public Descripcion Descripcion { get; private set; }
        public DateTime? FechaCreacion { get; private set; }

        private Comentario()
        {
            
        }

        private Comentario(Guid id, Guid vehiculoId, Guid alquilerId, Guid usuarioId, Rating rating, Descripcion descripcion, DateTime? fechaCreacion) : base(id)
        {
            VehiculoId = vehiculoId;
            AlquilerId = alquilerId;
            UsuarioId = usuarioId;
            Rating = rating;
            Descripcion = descripcion;
            FechaCreacion = fechaCreacion;
        }

        public static Result<Comentario> Create(Alquiler alquiler, Rating rating, Descripcion descripcion, DateTime fechaCreacion)
        {
            if (alquiler.Status != AlquilerStatus.Completado)
            {
                return Result.Failure<Comentario>(ComentariosErrors.NotEligible);
            }

            var review = new Comentario(Guid.NewGuid(), alquiler.VehiculoId, alquiler.Id, alquiler.UsuarioId, rating, descripcion, fechaCreacion);
            review.RaiseDomainEvent(new ReviewCreatedDomainEvent(review.Id));
            return review;
        }
    }
}
