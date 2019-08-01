using AccountServices.Domain.Interfaces;
using AccountServices.Infra.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace AccountServices.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        IDbContextTransaction _transaction;
        public AccountContext Context { get; private set; }

        public UnitOfWork(AccountContext context)
        {
            Context = context;
        }

        public void InitializeContext(bool withTransaction)
        {
            if (withTransaction)
                InitializeTransaction();
        }

        private void InitializeTransaction() =>
           _transaction = Context.Database.BeginTransaction();


        public void Commit()
        {
            Context?.SaveChanges();
            _transaction?.Commit();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            Context?.Dispose();
        }

        public void Rollback() =>
            _transaction?.Rollback();

        public void Save() =>
            Context?.SaveChanges();
    }
}
