namespace ApiTaxi.Aplicacion.CasosDeUso.Seguridad.Dtos
{
    public class ValidacionLoginResponseDto
    {
        public string Estado { get; set; } = null!; // "VALID" o "IN"
        public string IdUsuario { get; set; } = null!;
    }
}
