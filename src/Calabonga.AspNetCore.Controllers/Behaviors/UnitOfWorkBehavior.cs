using System.Threading;
using System.Threading.Tasks;

using Calabonga.UnitOfWork;

using MediatR;

namespace Calabonga.AspNetCore.Controllers.Behaviors
{
    /// <summary>
    /// Transaction Behavior
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class UnitOfWorkBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkBehavior(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = await next();
            await _unitOfWork.SaveChangesAsync();
            return response;
        }
    }
}
