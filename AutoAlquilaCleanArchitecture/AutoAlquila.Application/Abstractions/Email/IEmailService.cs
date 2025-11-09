
namespace AutoAlquila.Application.Abstractions.Email
{
    public interface IEmailService
    {
        Task SendEmailAsync(Domain.Usuarios.Email recipient, string subject, string body);
    }
}
