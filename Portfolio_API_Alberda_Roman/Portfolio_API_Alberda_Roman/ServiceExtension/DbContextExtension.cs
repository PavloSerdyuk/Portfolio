using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_API_Alberda_Roman.ServiceExtension
{
    public static class DbContextExtension
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("LocalDbConnection");

            services.AddDbContext<PortfolioContext>(options =>
            {
                options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Portfolio.Data"));
            });

        }
    }
}
