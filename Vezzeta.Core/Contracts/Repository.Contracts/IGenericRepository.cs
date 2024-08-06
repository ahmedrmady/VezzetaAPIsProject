using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezzeta.Core.Entities;
using Vezzeta.Core.Specifications;

namespace Vezzeta.Core.Contracts.Repository.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task<TEntity> GetById(int id);
        Task<TEntity> GetWithSpecs(ISpecifications<TEntity> specifications);

        Task<IReadOnlyList<TEntity>> GetAll();

        Task<IReadOnlyList<TEntity>> GetAllWithSpecs(ISpecifications<TEntity> specifications);

    }
}
