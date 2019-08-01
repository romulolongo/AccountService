using AccountServices.Domain.Interfaces.Repositories;
using AccountServices.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountServices.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public async virtual Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async virtual Task<TEntity> GetByGuidAsync(Guid guid)
        {
            return await _repository.GetByGuidAsync(guid);
        }

        public async virtual Task InsertAsync(TEntity obj)
        {
            if (obj == null)
                throw new ArgumentException("Register not found");

            await _repository.InsertAsync(obj);
        }

        public async virtual Task DeleteByGuidAsync(Guid guid)
        {
            var obj = await GetByGuidAsync(guid);

            if (obj == null)
                throw new ArgumentException("Register not found");

            await _repository.DeleteAsync(obj);
        }

        public async virtual Task UpdateAsync(TEntity obj)
        {
            if (obj == null)
                throw new ArgumentException("Register not found");

            await _repository.UpdateAsync(obj);
        }
    }
}
