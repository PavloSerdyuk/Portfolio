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
    public class TrainerService : ITrainerService
    {
        private readonly IRepository<Trainer> _trainerRepository;

        public TrainerService(IRepository<Trainer> trainerRepository) =>
            _trainerRepository = trainerRepository;

        public async Task<Trainer> CreateTrainer(TrainerModel trainer)
        {
            var addedTrainer = new Trainer()
            {
                Name = trainer.Name,
                Rate = trainer.Rate,
                TrainerId = trainer.TrainerId
            };
            addedTrainer = await _trainerRepository.CreateAsync(addedTrainer);
            await _trainerRepository.SaveChangesAsync();
            return addedTrainer;
        }
    }
}
