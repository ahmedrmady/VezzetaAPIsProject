using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezzeta.Core.Entities;
using Vezzeta.Core.Specifications;

namespace Vezzeta.Repository.SpecificationsEvaluator
{
    internal static class SpecificationsEvaluator
    { 

        public static IQueryable<T> GetQuery<T>(this IQueryable<T> StartQuery, ISpecifications<T> specs) where T : BaseEntity
        {
            var query = StartQuery;
            if (specs.Criteria != null)
                query.Where(specs.Criteria);

            if (specs.OrderBy is not null)
                query = query.OrderBy(specs.OrderBy);

            else if (specs.OrderByDec is not null)
                query = query.OrderByDescending(specs.OrderByDec);

            if (specs.IsPaginationEnabled)
                query = query.Skip(specs.Skip).Take(specs.Take);

            query = specs.Includes.Aggregate(query, (currentQuery, include) => currentQuery.Include(include));
            return query;
        }

    }
}
