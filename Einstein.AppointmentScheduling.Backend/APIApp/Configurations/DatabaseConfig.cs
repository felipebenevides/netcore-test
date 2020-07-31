using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Runtime.CompilerServices;

namespace APIApp.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var serviceProvider = services.BuildServiceProvider();

            if (services == null) throw new ArgumentNullException(nameof(services));

            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<AppointmentSchedulingDBContext>((serviceProvider, options) => {
                options.UseSqlServer(configuration.GetConnectionString("AppointmentDB"), providerOptions => providerOptions.EnableRetryOnFailure());
            });
        }
    }
}
