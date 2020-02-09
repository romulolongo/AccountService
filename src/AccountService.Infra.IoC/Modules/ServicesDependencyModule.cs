using AccountService.Application.Accounts.Interfaces;
using AccountService.Application.Accounts.Services;
using AccountServices.Domain.Interfaces.Services;
using SimpleInjector;

namespace AccountService.Infra.IoC.Modules
{
    public static class ServicesDependencyModule
    {
        public static void Register(Container container)
        {
            container.Register<IAccountServices, AccountServices.Domain.Services.AccountServices>(Lifestyle.Scoped);
            container.Register<IAccountAppService, AccountAppService>(Lifestyle.Scoped);
        }
    }
}
