
using AccountService.Application.Accounts.Interfaces;
using AccountService.Application.Accounts.Services;
using AccountServices.Domain.Interfaces;
using AccountServices.Domain.Interfaces.Repositories;
using AccountServices.Domain.Interfaces.Services;
using AccountServices.Infra.Data;
using AccountServices.Infra.Data.Context;
using AccountServices.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AccountService.Infra.IoC
{
    public class IoC
    {
        public void RegisterInjectionDepedecy(IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();
            services.AddScoped<IAccountServices, AccountServices.Domain.Services.AccountServices>();
            services.AddScoped<IAccountAppService, AccountAppService>();
            services.AddSingleton<DbContextOptions<AccountContext>>();
        }
    }
}
