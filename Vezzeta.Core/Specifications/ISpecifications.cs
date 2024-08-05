using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vezzeta.Core.Data.Entities;

namespace Vezzeta.Core.Specifications
{
    public interface ISpecifications<T> where T : BaseEntity
    {
        Expression<Func<T, bool>> Criteria { get; set; }

        List<Expression<Func<T, object>>> Includes { get; set; }

        Expression<Func<T, object>> OrderBy { get; set; }

        Expression<Func<T, object>> OrderByDec { get; set; }

        int Skip { get; set; }
        int Take { get; set; }

        bool IsPaginationEnabled { get; set; }


    }
}
