using AutoAlquila.Application.Abstractions.Email;

namespace AutoAlquila.Infraestructure.Email
{
    internal sealed class EmailService : IEmailService
    {
        public Task SendEmailAsync(Domain.Usuarios.Email recipient, string subject, string body)
        {
            return Task.CompletedTask;
        }
    }
}
