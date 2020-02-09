using AccountService.Application.Accounts.Mappers;
using AutoMapper;
using SimpleInjector;

namespace AccountService.Infra.IoC.Modules
{
    public class AutoMapperDependencyModule
    {

        public static void Register(Container container)
        {
            var mapping = CreateMapping();

            container.RegisterInstance(mapping);
        }

        private static IMapper CreateMapping()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AccountEntitiesProfile());
                mc.AddProfile(new AccountResponsesProfile());
            });

            return mappingConfig.CreateMapper();
        }

    }
}
