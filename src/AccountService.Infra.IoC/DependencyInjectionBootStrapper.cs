using AccountService.Infra.IoC.Modules;
using SimpleInjector;

namespace AccountService.Infra.IoC
{
    public static class DependencyInjectionBootStrapper
    {
        public static void RegisterServices(this Container container)
        {
            UnitOfWorkModule.Register(container);
            ServicesModule.Register(container);
            RepositoryModule.Register(container);
            DbContextModule.Register(container);
        }

        #region InjectorAspnet
        // public void RegisterInjectionDepedecy(IServiceCollection services)
        //{
        //    services.AddScoped<IAccountRepository, AccountRepository>();
        //    services.AddScoped<IUnitOfWork, UnitOfWork>();
        //    services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();
        //    services.AddScoped<IAccountServices, AccountServices.Domain.Services.AccountServices>();
        //    services.AddScoped<IAccountAppService, AccountAppService>();
        //    services.AddSingleton<DbContextOptions<AccountContext>>();
        //}
        #endregion
    }
}
