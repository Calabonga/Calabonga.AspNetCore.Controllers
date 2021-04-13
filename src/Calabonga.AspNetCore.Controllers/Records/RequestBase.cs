using Calabonga.OperationResults;
using MediatR;

namespace Calabonga.AspNetCore.Controllers.Records
{
    /// <summary>
    /// Default request as the base for all requests. All requests should have your own name.
    /// </summary>
    public abstract record RequestBase<TResponse> : RequestBase, IRequest<TResponse>;

    /// <summary>
    /// Default request as the base for all requests. All requests should have your own name.
    /// </summary>
    public abstract record RequestBase : INamedRequest
    {
        /// <summary>
        /// Current query public (friendly) name
        /// </summary>
        public virtual string RequestName => GetType().Name;
    }

    /// <summary>
    /// Default request as the base for all requests with OperationResult wrapper response. All requests should have your own name.
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public abstract record OperationResultRequestBase<TResponse> : RequestBase<OperationResult<TResponse>>;
}
