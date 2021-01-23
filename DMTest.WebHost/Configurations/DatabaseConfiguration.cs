using DMTest.Domain.Security.Settings;
using DMTest.Infrastructure.Data;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DMTest.WebHost.Configurations
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Database settings
            services.Configure<DataBaseSettings>(configuration.GetSection(nameof(DataBaseSettings)));
            var databaseSettings = services.BuildServiceProvider()
                .GetService<IOptions<DataBaseSettings>>()
                .Value;

            services.AddDbContext<DMTestContext>(options =>
                options.UseInMemoryDatabase(databaseName: databaseSettings.ContextConnection));

            return services;
        }

        public static void Configure(IApplicationBuilder app)
        {

        }
    }
}
