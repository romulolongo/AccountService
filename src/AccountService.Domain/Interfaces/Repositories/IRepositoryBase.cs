using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountServices.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task InsertAsync(TEntity obj);
        Task<TEntity> GetByGuidAsync(Guid guid);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity obj);
        Task DeleteAsync(TEntity obj);
    }
}
