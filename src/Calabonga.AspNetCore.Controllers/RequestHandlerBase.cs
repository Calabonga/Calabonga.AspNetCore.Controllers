using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Calabonga.AspNetCore.Controllers
{
    /// <summary>
    /// Default class for request handler
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class RequestHandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        /// <summary>Handles a request</summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from the request</returns>
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}