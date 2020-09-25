using System.Threading;
using System.Threading.Tasks;
using Calabonga.OperationResults;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Calabonga.AspNetCore.Controllers.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var queryName = "Untitled Query";
            if (request is INamedRequest namedRequest)
            {
                queryName = namedRequest.QueryName;
            }
            var messageBefore = $"{queryName} started";
            _logger.LogInformation(messageBefore);
            var response = await next();
            var messageAfter = $"{queryName} completed";
            var operation = response as OperationResult;
            operation?.AppendLog(messageAfter);
            _logger.LogInformation(messageAfter);
            return response;
        }
    }
}