using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PyxisBackend.Contracts;
using PyxisBackend.Contracts.Models;
using PyxisBackend.Entities;
using PyxisBackend.LoggerService;
using PyxisBackend.Repository.Models;

namespace PyxisBackend.Core.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .WithMethods("POST", "GET", "PUT")
                    .AllowAnyHeader());
            });
        }

        /// <summary>
        /// Configure an Logger Service according to the PyxisBackend.LoggerService project.
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        /// <summary>
        /// Configure an IIS integration which will help us with the IIS deployment
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        /// <summary>
        /// Configure the RepositoryWrapper Service for the entities of Person and Pet
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapperPersonPet, RepositoryWrapperPersonPet>();
        }

        /// <summary>
        /// Configure the MySQL context according to the connection string at the appsettings.json file
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["mysqlconnection:connectionString"];
            services.AddDbContext<RepositoryContext>(o => o.UseMySql(connectionString));
        }

        /// <summary>
        /// Configure SQL Server context according to the connection string at the appsettings.json file
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void ConfigureSqlServerContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["sqlserverconnection:connectionString"];
            services.AddDbContext<RepositoryContext>(o => o.UseSqlServer(connectionString));
        }
    }
}
