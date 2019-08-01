namespace AccountServices.Domain.Interfaces
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork StartUnitOfWork(bool usingTransaction = false);
    }
}
