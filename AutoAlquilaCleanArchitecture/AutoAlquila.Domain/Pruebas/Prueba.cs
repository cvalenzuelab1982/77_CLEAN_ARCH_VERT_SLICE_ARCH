namespace AutoAlquila.Domain.Pruebas
{
    public sealed class Prueba
    {
        public int Id { get; private set; }
        public string? Nombre { get; private set; }

        private Prueba() { }

        public Prueba(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
    }
}
