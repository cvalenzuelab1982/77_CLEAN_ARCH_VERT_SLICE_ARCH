using AutoAlquila.Application.Abstractions.Clock;

namespace AutoAlquila.Infraestructure.Clock
{
    internal sealed class DateTimeProvider : IDateTimeProvider
    {
        public DateTime CurrentTime => DateTime.UtcNow;
    }

}
