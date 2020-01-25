using AccountServices.Infra.Data.Context;
using SimpleInjector;

namespace AccountService.Infra.IoC.Modules
{
    public static class DbContextModule
    {
        public static void Register(Container container)
        {
            container.Register<AccountContext>(Lifestyle.Singleton);
        }
    }
}
