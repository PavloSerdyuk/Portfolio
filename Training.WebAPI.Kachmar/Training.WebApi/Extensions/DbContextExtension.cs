using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Training.WebApi.Extensions
{
    public static class DbContextExtension
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("LocalDbConnection");

            services.AddDbContext<TrainingContext>(options =>
            {
                options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Training.DAL"));
            });

        }
    }
}
