using MediatR;

namespace Calabonga.AspNetCore.Controllers.Base
{
    /// <summary>
    ///  Default request as the base for all requests. All requests should have your own name.
    /// </summary>
    public abstract class RequestBase<TResponse> : RequestBase, IRequest<TResponse>
    {

    }

    /// <summary>
    ///  Default request as the base for all requests. All requests should have your own name.
    /// </summary>
    public abstract class RequestBase : INamedRequest
    {
        /// <summary>
        /// Current query public (friendly) name
        /// </summary>
        public virtual string QueryName => GetType().Name;
    }
}