using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezzeta.Core.Contracts;
using Vezzeta.Core.Contracts.Repository.Contracts;
using Vezzeta.Core.Entities;
using Vezzeta.Repository.Data;
using Vezzeta.Repository.Repository;

namespace Vezzeta.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private Hashtable Repositoreis { get; set; }

        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
            Repositoreis = new Hashtable();
        }
        public async Task<bool> Compelte()
        =>await _context.SaveChangesAsync()>0;

        public async ValueTask DisposeAsync()
       =>await _context.DisposeAsync(); 

        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            var type = typeof(T).Name;
            if (!Repositoreis.ContainsKey(type))
            {
                var repo = new GenericRepository<T>(_context);
                Repositoreis.Add(type, repo);
            }
            return Repositoreis[type] as IGenericRepository<T>;
        }
    }
}
