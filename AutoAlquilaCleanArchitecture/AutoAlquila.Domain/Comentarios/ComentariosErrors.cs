using AutoAlquila.Domain.Abstractions;

namespace AutoAlquila.Domain.Comentarios
{
    public static class ComentariosErrors
    {
        public static readonly Error NotEligible = new(
            "Comentarios.NotEligible",
            "Este comentario y calificacion para el auto no es elegible por que aun no se completa"
        );
    }
}
