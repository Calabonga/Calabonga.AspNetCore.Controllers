using Calabonga.AspNetCore.Controllers.Base;
using Calabonga.EntityFrameworkCore.Entities.Base;
using Calabonga.Microservices.Core.QueryParams;

namespace Calabonga.AspNetCore.Controllers.Queries
{
    /// <summary>
    /// Get Paged Query base implementation
    /// </summary>
    public abstract class GetPagedQuery<TResponse, TQueryParams> :
        PagedListOperationResultEntityRequest<TResponse, TQueryParams>
        where TQueryParams : PagedListQueryParams
        where TResponse : ViewModelBase
    {
        protected GetPagedQuery(TQueryParams queryParams)
            : base(queryParams)
        {
            
        }
    }
}