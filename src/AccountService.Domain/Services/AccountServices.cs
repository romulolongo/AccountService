using AccountServices.Domain.Entities;
using AccountServices.Domain.Interfaces.Repositories;
using AccountServices.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountServices.Domain.Services
{
    public class AccountServices : ServiceBase<Account>, IAccountServices
    {
        private readonly IAccountRepository _accountRepositoryRepository;

        public AccountServices(IAccountRepository accountRepository)
            : base(accountRepository)
        {
            _accountRepositoryRepository = accountRepository;
        }

        public async override Task<IEnumerable<Account>> GetAllAsync()
        {
            var accounts = await _accountRepositoryRepository.GetAllAsync();

            if (accounts == null || !accounts.Any())
                throw new ArgumentException("Accounts not Found");

            return accounts;
        }

        public async override Task<Account> GetByGuidAsync(Guid guid)
        {
            var account = await _accountRepositoryRepository.GetByGuidAsync(guid);

            if (account == null)
                throw new ArgumentException("Account not Found");

            return account;
        }

        public async override Task InsertAsync(Account account)
        {
            if (account == null || !account.IsValid())
                throw new ArgumentException("Account not Valid");

            await _accountRepositoryRepository.InsertAsync(account);
        }

        public async override Task UpdateAsync(Account account)
        {
            if (account == null || !account.IsValid())
                throw new ArgumentException("Account not Valid");

            await _accountRepositoryRepository.UpdateAsync(account);
        }
    }
}
