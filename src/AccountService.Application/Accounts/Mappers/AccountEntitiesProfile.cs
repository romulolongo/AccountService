using AccountService.Application.Accounts.Requests;
using AccountService.Application.Accounts.Responses;
using AccountServices.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

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
