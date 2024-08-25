using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezzeta.Core.Contracts.Repository.Contracts;
using Vezzeta.Repository.SpecificationsEvaluator;

using Vezzeta.Core.Entities;
using Vezzeta.Core.Specifications;
using Vezzeta.Repository.Data;


namespace Vezzeta.Repository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            this._context = context;

        }

        public void Add(T entity)
        => _context.Set<T>().Add(entity);


        public void Delete(T entity)
        => _context.Set<T>().Add(entity);

        public async Task<IReadOnlyList<T>> GetAll()
       => await _context.Set<T>().AsNoTracking().ToListAsync();

        public async Task<IReadOnlyList<T>> GetAllWithSpecs(ISpecifications<T> specifications)
       => await _context.Set<T>().GetQuery(specifications).AsNoTracking().ToListAsync();

        public async Task<T> GetById(int id)
        => await _context.Set<T>().FindAsync(id);

        public async Task<T> GetWithSpecs(ISpecifications<T> specifications)
        => await _context.Set<T>().GetQuery<T>(specifications).FirstOrDefaultAsync();

        public void Update(T entity)
       => _context.Set<T>().Update(entity);
    }
}
