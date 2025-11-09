using AutoAlquila.Application.Abstractions.Messaging;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AutoAlquila.Application.Abstractions.Behaviors
{
    public class LoggingBehavior<TRequest, Tresponse> : IPipelineBehavior<TRequest, Tresponse> where TRequest : IBaseCommand
    {
        private readonly ILogger<TRequest> _logger;

        public LoggingBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<Tresponse> Handle(TRequest request, RequestHandlerDelegate<Tresponse> next, CancellationToken cancellationToken)
        {
            var name = request.GetType().Name;

            try
            {
                _logger.LogInformation($"Ejecutando el command request: {name}");
                var result = await next();
                _logger.LogInformation($"El comando {name} se ejecuto exitosamente");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"El comando {name} tuvo errores");
                throw;
            }
        }
    }
}
