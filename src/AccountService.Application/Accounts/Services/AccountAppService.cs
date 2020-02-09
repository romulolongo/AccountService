using AccountService.Application.Accounts.Interfaces;
using AccountService.Application.Accounts.Requests;
using AccountService.Application.Accounts.Responses;
using AccountServices.Domain.Entities;
using AccountServices.Domain.Interfaces;
using AccountServices.Domain.Interfaces.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountService.Application.Accounts.Services
{
    public class AccountAppService : AppServiceBase<Account>, IAccountAppService
    {
        private readonly IAccountServices _accountService;
        readonly IUnitOfWorkFactory _unitOfWorkFactory;
        readonly IMapper _mapper;

        public AccountAppService(IAccountServices accountService, IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper)
            : base(accountService)
        {
            _accountService = accountService;
            _unitOfWorkFactory = unitOfWorkFactory;
            _mapper = mapper;
        }

        public async Task DeleteByGuidAsync(Guid guid)
        {
            using (var unitOfWork = _unitOfWorkFactory.StartUnitOfWork())
            {
                await _accountService.DeleteByGuidAsync(guid);
                unitOfWork.Save();
            }
        }

        public async Task<IEnumerable<GetAllAccountResponse>> GetAllAsync()
        {
            using (_unitOfWorkFactory.StartUnitOfWork())
                return _mapper.Map<List<GetAllAccountResponse>>(
                               await _accountService.GetAllAsync());
        }

        public async Task<GetByGuidAccountResponse> GetByGuidAsync(Guid guid)
        {
            using (_unitOfWorkFactory.StartUnitOfWork())
                return _mapper.Map<GetByGuidAccountResponse>(
                               await _accountService.GetByGuidAsync(guid));
        }

        public async Task InsertAsync(InsertAccountRequest request)
        {
            using (var unitOfWork = _unitOfWorkFactory.StartUnitOfWork())
            {
                await _accountService.InsertAsync(
                    _mapper.Map<Account>(request));
                unitOfWork.Save();
            }
        }

        public async Task UpdateAsync(UpdateAccountRequest request)
        {
            using (var unitOfWork = _unitOfWorkFactory.StartUnitOfWork())
            {
                await _accountService.UpdateAsync(
                    _mapper.Map<Account>(request));
                unitOfWork.Save();
            }
        }
    }
}
