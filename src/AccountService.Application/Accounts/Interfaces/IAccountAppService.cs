using AccountService.Application.Accounts.Requests;
using AccountService.Application.Accounts.Responses;
using AccountServices.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountService.Application.Accounts.Interfaces
{
    public interface IAccountAppService : IAppServiceBase<Account>
    {

        Task InsertAsync(InsertAccountRequest request);
        Task<GetByGuidAccountResponse> GetByGuidAsync(Guid guid);
        Task<IEnumerable<GetAllAccountResponse>> GetAllAsync();
        Task UpdateAsync(UpdateAccountRequest request);
        Task DeleteByGuidAsync(Guid guid);
    }
}
