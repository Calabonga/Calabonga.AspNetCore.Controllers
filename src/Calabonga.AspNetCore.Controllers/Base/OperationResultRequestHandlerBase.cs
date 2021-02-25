using Calabonga.OperationResults;

using MediatR;

namespace Calabonga.AspNetCore.Controllers.Base
{
    /// <summary>
    /// Mediator base request with OperationResult
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <typeparam name="TRequest"></typeparam>
    public abstract class OperationResultRequestHandlerBase<TRequest, TResponse>
        : RequestHandlerBase<TRequest, OperationResult<TResponse>>
        where TRequest : IRequest<OperationResult<TResponse>>
    {

    }
}