using AccountServices.Infra.Data.Context;
using SimpleInjector;

namespace AccountService.Infra.IoC.Modules
{
    public static class DbContextDependencyModule
    {
        public static void Register(Container container)
        {
            container.Register<AccountContext>(Lifestyle.Scoped);
        }
    }
}
