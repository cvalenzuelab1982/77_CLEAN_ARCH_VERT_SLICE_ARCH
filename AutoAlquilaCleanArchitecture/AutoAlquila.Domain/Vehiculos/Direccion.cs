namespace AutoAlquila.Domain.Vehiculos
{
    public record Direccion(
        string Departamento,
        string Provincia,
        string Ciudad,
        string Pais,
        string Calle
    );
}
