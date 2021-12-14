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
    public interface ITrainingSessionService
    {
        Task<TrainingSession> GetTrainingSession(long trainingSessionId);
        Task<TrainingSession> CreateTrainingSession(TrainingSessionModel trainingSession);
        Task<TrainingSession> UpdateTrainingSession(TrainingSessionModel trainingSession);
    }
}
