using DMTest.Services.RestServices;
using DMTest.WebHost.Configurations;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DMTest.WebHost
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Api Rest Configuration
            RestServiceConfiguration.ConfigureServices(services);

            // Database configuration
            DatabaseConfiguration.ConfigureServices(services, Configuration);

            //Swagger configure
            SwaggerConfiguration.ConfigureServices(services);

            // Log
            services.AddLogging();

            // Cors
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseCors(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            }

            RestServiceConfiguration.Configure(app);
            DatabaseConfiguration.Configure(app);
            SwaggerConfiguration.Configure(app);
        }
    }
}
