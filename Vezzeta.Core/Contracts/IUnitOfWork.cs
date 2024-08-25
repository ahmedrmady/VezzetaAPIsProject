using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezzeta.Core.Contracts.Repository.Contracts;
using Vezzeta.Core.Entities;

namespace Vezzeta.Core.Contracts
{
    public interface IUnitOfWork :IAsyncDisposable
    {
        IGenericRepository<T> Repository<T>() where T : BaseEntity;

        Task<bool> Compelte();
    }
}
