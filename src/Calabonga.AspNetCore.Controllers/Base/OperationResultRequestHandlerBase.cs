using Calabonga.OperationResults;
using MediatR;

namespace Calabonga.AspNetCore.Controllers.Base
{
    /// <summary>
    /// Mediator base request with OperationResult
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <typeparam name="TRequest"></typeparam>
    public abstract class OperationResultRequestHandlerBase<TRequest, TResponse> : RequestHandlerBase<TRequest, OperationResult<TResponse>>
        where TRequest : IRequest<OperationResult<TResponse>>
    {
        /// <summary>
        /// Process operation result
        /// </summary>
        /// <param name="operationResult"></param>
        /// <returns></returns>
        protected virtual OperationResult<TResponse> OperationResultBeforeReturn(OperationResult<TResponse> operationResult)
        {
            return operationResult;
        }

        /// <summary>
        /// Process operation result
        /// </summary>
        /// <param name="operationResult"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        protected virtual OperationResult<TResponse> ProcessOperationResult(OperationResult<TResponse> operationResult, TResponse response)
        {
            return null;
        }
    }
}