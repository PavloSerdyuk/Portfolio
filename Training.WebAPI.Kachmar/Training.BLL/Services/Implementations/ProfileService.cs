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
using System.Collections.ObjectModel;

namespace Training.BLL.Services.Implementations
{
    public class ProfileService : IProfileService
    {
        private readonly IRepository<Profile> _profileRepository;
        private readonly IRepository<Subscribtion> _subscribtionRepository;
        private readonly IRepository<TrainingSession> _trainingRepository;

        public ProfileService(IRepository<Profile> profileRepository,
            IRepository<Subscribtion> subscribtionRepository,
            IRepository<TrainingSession> trainingRepository)
        {
            _profileRepository = profileRepository;
            _subscribtionRepository = subscribtionRepository;
            _trainingRepository = trainingRepository;
        }

        public async Task<Profile> GetProfile(long profileId) =>
            await _profileRepository.GetByKeys(profileId);

        public async Task<Profile> AddTrainingToProfile(long profileId, long trainingId)
        {
            var updatedProfile = await _profileRepository.GetByKeys(profileId);

            if (updatedProfile is null)
            {
                throw new Exception("No profile for provided profileId found");
            }

            var newTraining = await _trainingRepository.GetByKeys(trainingId);
            newTraining.ProfileId = profileId;
            newTraining.Profile = updatedProfile;
            _trainingRepository.UpdateAsync(newTraining);
            await _trainingRepository.SaveChangesAsync();

            updatedProfile.Trainings.Add(newTraining);
            _profileRepository.UpdateAsync(updatedProfile);
            await _profileRepository.SaveChangesAsync();
            return updatedProfile;
        }

        public async Task<Profile> CreateProfile(ProfileModel profile)
        {
            var assignedSubscribtion = _subscribtionRepository.GetAllAsync().GetAwaiter().GetResult().FirstOrDefault();

            var newProfile = new Profile()
            {
                ProfileId = profile.ProfileId,
                Name = profile.Name,
                Surname = profile.Surname,
                SubscribtionId = assignedSubscribtion.SubscribtionId,
                Trainings = new Collection<TrainingSession>()
            };

            await _profileRepository.CreateAsync(newProfile);
            await _profileRepository.SaveChangesAsync();
            return newProfile;
        }

        public async Task<bool> DeleteProfile(long profileId)
        {
            var deletedprofile = await _profileRepository.GetByKeys(profileId);
            var isDeleted = await _profileRepository.DeleteAsync(deletedprofile);
            await _profileRepository.SaveChangesAsync();

            if (isDeleted is true)
            {
                return isDeleted;
            }
            throw new Exception("Profile haven't been deleted");
        }

        public Task<List<TrainingSession>> GetAllProfileTrainings(long profileId)
        {
            throw new NotImplementedException();
        }

        public Task<Profile> UpdateProfile(ProfileModel profile)
        {
            throw new NotImplementedException();
            //save changes
        }
    }
}
