using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DMTest.WebHost.Configurations
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "SUPUESTO PRACTICO BACKEND DEVELOPER .NET",
                    Description = "API del aplicativo para la prueba BACKEND DEVELOPER .NET, construido en ASP.NET Core 3.1 Web API",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Email = "demorales13@outlook.com",
                        Name = "David Morales",
                        Url = new System.Uri("https://www.linkedin.com/in/david-eduardo-morales-mart%C3%ADnez-98b96351/")
                    }
                });
            });

            return services;
        }

        public static void Configure(IApplicationBuilder app)
        {
            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contacts API V1");
            });
        }
    }
}
