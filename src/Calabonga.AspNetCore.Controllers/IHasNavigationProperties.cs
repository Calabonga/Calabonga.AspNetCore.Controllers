﻿using System;
using System.Linq;
using Calabonga.EntityFrameworkCore.Entities.Base;
using Microsoft.EntityFrameworkCore.Query;

namespace Calabonga.AspNetCore.Controllers
{
    /// <summary>
    /// Inherited item can have navigation property
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IHasNavigationProperties<TEntity> where TEntity : Identity
    {
        /// <summary>
        /// Returns include predicate
        /// </summary>
        /// <returns></returns>
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> DefaultIncludes();

    }
}