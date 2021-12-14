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
    public class TrainingSessionService : ITrainingSessionService
    {
        private readonly IRepository<TrainingSession> _trainingSessionRepository;
        private readonly IRepository<Profile> _profileRepository;

        public TrainingSessionService(IRepository<TrainingSession> trainingSessionRepository,
            IRepository<Profile> profileRepository)
        {
            _trainingSessionRepository = trainingSessionRepository;
            _profileRepository = profileRepository;
        }

        public async Task<TrainingSession> CreateTrainingSession(TrainingSessionModel trainingSession)
        {
            var profile = await _profileRepository.GetByKeys((long)1);
            var training = new TrainingSession()
            {
                Profile = profile,
                ProfileId = profile.ProfileId,
                TrainerName = trainingSession.TrainerName,
                TrainingId = trainingSession.TrainingId,
                TrainingTime = DateTime.Now
            };

            return training;
        }

        public async Task<TrainingSession> GetTrainingSession(long trainingSessionId) =>
            await _trainingSessionRepository.GetByKeys(trainingSessionId);

        public Task<TrainingSession> UpdateTrainingSession(TrainingSessionModel trainingSession)
        {
            throw new NotImplementedException();
        }
    }
}
