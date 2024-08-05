using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vezzeta.Core.Entities;

namespace Vezzeta.Core.Specifications
{
    public class BaseSpecifications<T> : ISpecifications<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; }
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDec { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPaginationEnabled { get; set; }
        public BaseSpecifications() //without Criteria 
        {

        }

        public BaseSpecifications(Expression<Func<T, bool>> criteria) //with Criteria 
        {
            Includes = new List<Expression<Func<T, object>>>();
        }
       

        public void AddCriteria(Expression<Func<T, bool>> criteria)
            => Criteria = criteria;
        public void AddInclud(Expression<Func<T, object>> include)
            => Includes.Add(include);

        public void AddOrderBy(Expression<Func<T, object>> orderBy) => OrderBy = orderBy;
        public void AddOrderByDec(Expression<Func<T, object>> orderByDec) => OrderByDec = orderByDec;

        void ApplyPagination(int skip, int take)
        {
           Skip = skip;
            Take = take;
            IsPaginationEnabled = true;
        }


    }
}
