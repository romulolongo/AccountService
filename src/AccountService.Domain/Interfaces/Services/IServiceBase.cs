using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountServices.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task InsertAsync(TEntity obj);
        Task<TEntity> GetByGuidAsync(Guid guid);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity obj);
        Task DeleteByGuidAsync(Guid gui);
    }
}
