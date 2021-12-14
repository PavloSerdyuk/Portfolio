using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.DAL.Repositories.Abstractions;
using Training.DAL.Repositories.Implementations;
using Training.DAL.Entities;
using Training.BLL.Models;

namespace Training.BLL.Services.Abstractions
{
    public interface IProfileService
    {
        Task<Profile> GetProfile(long profileId);
        Task<Profile> AddTrainingToProfile(long profileId, long trainingId);
        Task<List<TrainingSession>> GetAllProfileTrainings(long profileId);
        Task<Profile> CreateProfile(ProfileModel profile);
        Task<Profile> UpdateProfile(ProfileModel profile);
        Task<bool> DeleteProfile(long profile);
    }
}
