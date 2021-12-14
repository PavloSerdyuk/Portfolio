using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Training.BLL.Services.Abstractions;
using Training.BLL.Services.Implementations;
using Training.DAL.Repositories.Abstractions;
using Training.DAL.Repositories.Implementations;
using Training.DAL.Entities;
using Training.DAL;

namespace Training.WebApi.Extensions
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection service)
        {
            service.AddScoped<IRepository<Profile>, Repository<Profile>>();
            service.AddScoped<IRepository<TrainingSession>, Repository<TrainingSession>>();
            service.AddScoped<IRepository<Trainer>, Repository<Trainer>>();
            service.AddScoped<IRepository<Subscribtion>, Repository<Subscribtion>>();
            service.AddScoped<IProfileService, ProfileService>();
            service.AddScoped<ITrainerService, TrainerService>();
            service.AddScoped<ISubscribtionService, SubscribtionService>();
            service.AddScoped<ITrainingSessionService, TrainingSessionService>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
