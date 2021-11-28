using Microsoft.Extensions.DependencyInjection;
using Portfolio.Data.Entities;
using Portfolio.Data.Infrastructure;
using Portfolio.Domain.Services.Implementation;
using Portfolio.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_API_Alberda_Roman.ServiceExtension
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection service)
        {
            service.AddScoped<IRepository<Representation>, Repository<Representation>>();
            service.AddScoped<IRepository<User>, Repository<User>>();
            service.AddScoped<IRepresentationService, RepresentationService>();
            service.AddTransient<IUserService, UserService>();
        }
    }
}
