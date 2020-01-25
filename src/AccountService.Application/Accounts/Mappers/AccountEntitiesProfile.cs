using AccountService.Application.Accounts.Requests;
using AccountServices.Domain.Entities;
using AutoMapper;

namespace AccountService.Application.Accounts.Mappers
{
    public class AccountEntitiesProfile : Profile
    {
        public AccountEntitiesProfile()
        {
            CreateMap<InsertAccountRequest, Account>();
            CreateMap<UpdateAccountRequest, Account>();
        }
    }
}
