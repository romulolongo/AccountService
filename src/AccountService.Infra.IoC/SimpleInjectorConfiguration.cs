using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Microsoft.AspNetCore.Builder;

namespace AccountService.Infra.IoC
{
    public static class SimpleInjectorConfiguration
    {
        static Container _container = new Container();

        public static void AddSimpleInjenctorConfiguration(this IServiceCollection services)
        {
            _container.Options.DefaultScopedLifestyle =
                new AsyncScopedLifestyle();

            services.AddSimpleInjector(_container, options =>
            {
                options
                    .AddAspNetCore()
                    .AddControllerActivation();
            });

            services.UseSimpleInjectorAspNetRequestScoping(_container);

            _container.RegisterDependencies();
        }


        public static Container GetContainer(this IApplicationBuilder serviceCollection)
        {
            return _container;
        }


        public static void UseSimpleInjectorConfig(this IApplicationBuilder app)
        {
            app.UseSimpleInjector(_container);
        }
    }
}
