using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Training.DAL.Entities;
using Training.DAL.Repositories.Abstractions;

namespace Training.DAL
{
    public interface IUnitOfWork
    {
        IRepository<Trainer> TrainerRepository { get; }
        IRepository<TrainingSession> TrainingRepository { get; }
        IRepository<Subscribtion> SubscribtionRepository { get; }
        Task SaveChangesAsync(CancellationToken cancel);
    }
}
