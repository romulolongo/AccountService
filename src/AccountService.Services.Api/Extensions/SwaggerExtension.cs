using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace AccountService.Services.Api.Extensions
{
    public static class SwaggerExtension
    {

        public static void AddSwaggerConfguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Account",
                    Version = "v1"
                });
            });
        }
        public static void UseCustomSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Conexia Challenge V1");
            });
        }
    }
}
