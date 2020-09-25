using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;

using Calabonga.AspNetCore.Controllers.Demo.Entities;
using Calabonga.AspNetCore.Controllers.Demo.ViewModels;
using Calabonga.AspNetCore.Controllers.Handlers;
using Calabonga.AspNetCore.Controllers.Queries;
using Calabonga.Microservices.Core.QueryParams;
using Calabonga.OperationResults;
using Calabonga.PredicatesBuilder;
using Calabonga.UnitOfWork;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Calabonga.AspNetCore.Controllers.Demo.Controllers.Queries
{
    public class PersonPagedQuery : GetPagedQuery<PersonViewModel, PagedListQueryParams>
    {
        public PersonPagedQuery(PagedListQueryParams queryParams) : base(queryParams)
        {
        }
    }

    public class PersonPagedHandler : GetPagedHandlerBase<PersonPagedQuery, Person, PagedListQueryParams, PersonViewModel>
    {

        public PersonPagedHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        /// <summary>
        /// Returns Includes for entity
        /// </summary>
        /// <returns></returns>
        public override Func<IQueryable<Person>, IIncludableQueryable<Person, object>> DefaultIncludes()
        {
            return i => i.Include(x => x.Addresses);
        }

        /// <summary>
        /// Process operation result
        /// </summary>
        /// <param name="operationResult"></param>
        /// <returns></returns>
        public override OperationResult<IPagedList<PersonViewModel>> OperationResultBeforeReturn(OperationResult<IPagedList<PersonViewModel>> operationResult)
        {
            operationResult.AppendLog("OperationResultBeforeReturn FIRED!");
            operationResult.AddSuccess("Success added");
            operationResult.AppendLog("OperationResultResponse fired!");
            return operationResult;
        }

        /// <summary>
        /// Returns predicate for filtering before processing items
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        public override Expression<Func<Person, bool>> FilterItems(Expression<Func<Person, bool>> predicate,
            PagedListQueryParams queryParams)
        {
            if (string.IsNullOrEmpty(queryParams.Search))
            {

                return predicate;
            }

            var term = queryParams.Search.ToLower();
            predicate = predicate.And(x => x.FirstName.ToLower().Contains(term));
            predicate = predicate.Or(x => x.LastName.ToLower().Contains(term));
            predicate = predicate.Or(x => x.Addresses.Any(a => a.Content.ToLower().Contains(term)));
            predicate = predicate.Or(x => x.Addresses.Any(a => a.Name.ToLower().Contains(term)));

            return predicate;
        }

        
    }
}
