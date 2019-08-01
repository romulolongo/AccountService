using AccountService.Application.Accounts.Responses;
using AccountServices.Domain.Entities;
using AutoMapper;

namespace AccountService.Application.Accounts.Mappers
{
    public class AccountResponsesProfile : Profile
    {
        public AccountResponsesProfile()
        {
            CreateMap<Account, GetAllAccountResponse>();

            CreateMap<Account, GetByGuidAccountResponse>();
        }
    }
}
