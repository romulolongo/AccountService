using AccountServices.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using SimpleInjector;

namespace AccountService.Infra.IoC.Modules
{
    public static class DbContextModule
    {
        public static void Register(Container container)
        {
            container.Register<DbContextOptions<AccountContext>>(Lifestyle.Singleton);
        }
    }
}
