using System;
using System.Linq;
using System.Linq.Expressions;

using AutoMapper;

using Calabonga.EntityFrameworkCore.Entities.Base;
using Calabonga.OperationResults;
using Calabonga.UnitOfWork;

using MediatR;

using Microsoft.EntityFrameworkCore.Query;

namespace Calabonga.AspNetCore.Controllers.Base
{
    /// <summary>
    /// GetByIdentifier Handler
    /// </summary>
    public abstract class IncludesPropertyRequestHandler<TRequest, TEntity, TResponse>
        : OperationResultRequestHandlerBase<TRequest, TResponse>, IHasNavigationProperties<TEntity>
        where TRequest : IRequest<OperationResult<TResponse>>
        where TResponse : ViewModelBase
        where TEntity : Identity
    {

        protected IncludesPropertyRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            CurrentMapper = mapper;
        }

        /// <summary>
        /// Current instance of IMapper
        /// </summary>
        protected IMapper CurrentMapper { get; }

        /// <summary>
        /// Current instance of IUnitOfWork
        /// </summary>
        protected IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Returns Includes for entity
        /// </summary>
        /// <returns></returns>
        public virtual Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> DefaultIncludes()
        {
            return null;
        }

        /// <summary>
        /// Returns predicate for filtering before processing items
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        protected virtual Expression<Func<TEntity, bool>> FilterItems(Expression<Func<TEntity, bool>> predicate)
        {
            return predicate;
        }


    }
}