namespace AutoAlquila.Domain.Abstractions
{
    public record Error(string Code, string Description)
    {
        public static Error None = new(string.Empty, string.Empty);
        public static Error NullValue = new("Error.nullValue", "un valor NULL fue ingresado");
    }

}
