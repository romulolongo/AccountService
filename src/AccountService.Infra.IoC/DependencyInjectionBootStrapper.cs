using AccountService.Infra.IoC.Modules;
using SimpleInjector;

namespace AccountService.Infra.IoC
{
    public static class DependencyInjectionBootStrapper
    {
        public static void RegisterDependencies(this Container container)
        {
            UnitOfWorkDependencyModule.Register(container);
            ServicesDependencyModule.Register(container);
            RepositoryDependencyModule.Register(container);
            DbContextDependencyModule.Register(container);
            AutoMapperDependencyModule.Register(container);
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
