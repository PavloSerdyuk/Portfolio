using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.DAL.Repositories.Abstractions;
using Training.DAL.Repositories.Implementations;
using Training.DAL.Entities;
using Training.BLL.Models;
using Training.BLL.Services.Abstractions;

namespace Training.BLL.Services.Implementations
{
    public class SubscribtionService : ISubscribtionService
    {
        private readonly IRepository<Subscribtion> _subscribtionRepository;

        public SubscribtionService(IRepository<Subscribtion> subscribtionRepository) =>
            _subscribtionRepository = subscribtionRepository;

        public async Task<Subscribtion> CreateSubscribtion(SubscribtionModel subscribtion)
        {
            var newSubscribtion = new Subscribtion()
            {
                SubscribtionId = subscribtion.SubscribtionId,
                SubscribtionName = subscribtion.SubscribtionName,
                SubscribtionCost = subscribtion.SubscribtionCost,
                WeekWorkoutHours = subscribtion.WeekWorkoutHours,
            };
            var addedSubscribtion = await _subscribtionRepository.CreateAsync(newSubscribtion);
            await _subscribtionRepository.SaveChangesAsync();
            return addedSubscribtion;
        }

        public async Task<Subscribtion> GetSubscribtion(long subscribtionId) =>
            await _subscribtionRepository.GetByKeys(subscribtionId);
    }
}
