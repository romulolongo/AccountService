using AccountServices.Domain.Interfaces.Repositories;
using AccountServices.Infra.Data.Repositories;
using SimpleInjector;

namespace AccountService.Infra.IoC.Modules
{
    public static class RepositoryModule
    {
        public static void Register(Container container)
        {
            container.Register<IAccountRepository, AccountRepository>(Lifestyle.Scoped);
        }
    }
}
