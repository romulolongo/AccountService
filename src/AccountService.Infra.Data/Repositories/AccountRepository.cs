using AccountServices.Domain.Entities;
using AccountServices.Domain.Interfaces;
using AccountServices.Domain.Interfaces.Repositories;

namespace AccountServices.Infra.Data.Repositories
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        private readonly UnitOfWork _unitOfWork;

        public AccountRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }
    }
}
