using AutoMapper;

using DMTest.Domain.Interface;
using DMTest.Domain.Interface.Services;
using DMTest.Infrastructure.Data;
using DMTest.Services.AppServices;
using DMTest.Services.RestServices.ViewModels.Validations;

using FluentValidation.AspNetCore;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using System;

namespace DMTest.Services.RestServices
{
    public class RestServiceConfiguration
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            // Automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // MVC with calmel case format
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .AddNewtonsoftJson(option =>
                {
                    option.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    option.SerializerSettings.MaxDepth = 5;
                    option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            // Api Versioning
            services.AddApiVersioning(setup =>
            {
                setup.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                setup.AssumeDefaultVersionWhenUnspecified = true;
            });

            // Add fluent validation implicit service
            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RouletteChangeStatusViewModelValidator>());

            // Services
            services.AddScoped<IBetServices, BetServices>();
            services.AddScoped<IRouletteService, RouletteService>();
            services.AddScoped<IUserServices, UserServices>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
