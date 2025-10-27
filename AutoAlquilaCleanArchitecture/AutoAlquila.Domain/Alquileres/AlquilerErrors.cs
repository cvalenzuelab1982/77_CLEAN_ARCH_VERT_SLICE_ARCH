using AutoAlquila.Domain.Abstractions;

namespace AutoAlquila.Domain.Alquileres
{
    public static class AlquilerErrors
    {
        public static Error Notfound = new Error
        (
            "Alquiler.Notfound",
            "El alquiler con el Id especificado no fue encontrado"
        );

        public static Error Overlap = new Error
        (
            "Alquiler.Overlap",
            "El alquiler esta siendo tomando por 2 o mas cliente al mismo tiempom en la misma fecha"
        );

        public static Error NotReserved = new Error
        (
            "Alquiler.NotReserved",
            "El alquiler no esta reservado"
        );

        public static Error NotConfirmed = new Error
        (
            "Alquiler.NotConfirmed",
            "El alquiler no esta reservado"
        );

        public static Error AlreadyStarted = new Error
        (
            "Alquiler.AlreadyStarted",
            "El alquiler ya ha comenzado"
        );
    }
}
