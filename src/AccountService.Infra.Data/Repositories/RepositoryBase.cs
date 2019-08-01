using AccountServices.Domain.Interfaces;
using AccountServices.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountServices.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        readonly UnitOfWork _unitOfWork;

        public RepositoryBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public async virtual Task<TEntity> GetByGuidAsync(Guid guid) =>
            await _unitOfWork.Context.Set<TEntity>().FindAsync(guid);

        public async virtual Task<IEnumerable<TEntity>> GetAllAsync() =>
             await _unitOfWork.Context.Set<TEntity>().ToListAsync();

        public async virtual Task InsertAsync(TEntity obj)
        {
            await _unitOfWork.Context.Set<TEntity>().AddAsync(obj);
            await _unitOfWork.Context.SaveChangesAsync();
        }

        public async virtual Task UpdateAsync(TEntity obj)
        {
            _unitOfWork.Context.Entry(obj).State = EntityState.Modified;
            await _unitOfWork.Context.SaveChangesAsync();
        }

        public async virtual Task DeleteAsync(TEntity obj)
        {
            _unitOfWork.Context.Set<TEntity>().Remove(obj);
            await _unitOfWork.Context.SaveChangesAsync();
        }
    }
}
