using AccountService.Infra.IoC;
using AccountService.Services.Api.Extensions;
using AccountServices.Infra.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector.Lifestyles;

namespace AccountService.Services.Api
{
    public class Startup
    {
        readonly string _allowOriginPolicy = "AllowOrigin";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AccountContext>();

            services
                .AddMvcCore()
                .AddJsonFormatters()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services
                .AddSwaggerConfguration();

            services
                .AddSimpleInjenctorConfiguration();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSimpleInjectorConfig();
            app.UseCors(_allowOriginPolicy);
            app.UseMvcWithDefaultRoute();
            app.UseCustomSwaggerConfig();

            var container = app.GetContainer();

            using (AsyncScopedLifestyle.BeginScope(container))
            {
                var dbContext = container.GetService<AccountContext>();

                dbContext.Database.EnsureCreated();
            }
        }
    }
}
