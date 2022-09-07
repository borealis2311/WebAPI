using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> RepositoryAsync<TEntity>() where TEntity : class;
        int Save();
        Task<int> SaveChangesAsync();
    }
}
