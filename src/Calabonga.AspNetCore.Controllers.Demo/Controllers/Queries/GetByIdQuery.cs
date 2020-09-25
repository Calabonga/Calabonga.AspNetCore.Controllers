using System;
using System.Linq;
using System.Linq.Expressions;

using AutoMapper;

using Calabonga.AspNetCore.Controllers.Demo.Entities;
using Calabonga.AspNetCore.Controllers.Demo.ViewModels;
using Calabonga.AspNetCore.Controllers.Handlers;
using Calabonga.AspNetCore.Controllers.Queries;
using Calabonga.OperationResults;
using Calabonga.UnitOfWork;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Calabonga.AspNetCore.Controllers.Demo.Controllers.Queries
{
    public class PersonByIdQuery : GetByIdQuery<PersonViewModel>
    {
        public PersonByIdQuery(Guid id) : base(id)
        {
        }
    }

    public class PersonGetByIdHandler : GetByIdHandlerBase<PersonByIdQuery, Person, PersonViewModel>
    {
        public PersonGetByIdHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        /// <summary>
        /// Returns predicate for filtering before processing items
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        protected override Expression<Func<Person, bool>> FilterItems(Expression<Func<Person, bool>> predicate)
        {
            return i => i.FirstName.EndsWith("Name2");
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
        protected override OperationResult<PersonViewModel> OperationResultBeforeReturn(OperationResult<PersonViewModel> operationResult)
        {
            operationResult.AppendLog("OperationResultBeforeReturn FIRED!");
            operationResult.AddSuccess("Success added");
            return operationResult;
        }
    }
}
