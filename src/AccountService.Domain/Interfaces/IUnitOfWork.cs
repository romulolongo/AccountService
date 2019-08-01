using System;

namespace AccountServices.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        void Commit();
        void Rollback();
    }
}
