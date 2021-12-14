using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Training.DAL.Entities;
using Training.DAL.Repositories.Abstractions;
using Training.DAL.Repositories.Implementations;

namespace Training.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TrainingContext _Context;
        private IRepository<Trainer> _TrainerRepository;
        private IRepository<TrainingSession> _TrainingSessionRepository;
        private IRepository<Subscribtion> _SubscribtionRepository;
        private IRepository<Profile> _ProfileRepository;

        public UnitOfWork(TrainingContext Context)
        {
            this._Context = Context;
        }

        public IRepository<Subscribtion> SubscribtionRepository
        {
            get
            {
                if (_SubscribtionRepository == null)
                {
                    _SubscribtionRepository = new Repository<Subscribtion>(_Context);
                }
                return _SubscribtionRepository;
            }
        }
        public IRepository<Profile> ProfileRepository
        {
            get
            {
                if (_ProfileRepository == null)
                {
                    _ProfileRepository = new Repository<Profile>(_Context);
                }
                return _ProfileRepository;
            }
        }
        public IRepository<TrainingSession> TrainingRepository
        {
            get
            {
                if (_TrainingSessionRepository == null)
                {
                    _TrainingSessionRepository = new Repository<TrainingSession>(_Context);
                }
                return _TrainingSessionRepository;
            }
        }
        public IRepository<Trainer> TrainerRepository
        {
            get
            {
                if (_TrainerRepository == null)
                {
                    _TrainerRepository = new Repository<Trainer>(_Context);
                }
                return _TrainerRepository;
            }
        }

        public async Task SaveChangesAsync(CancellationToken Cancel)
        {
            await _Context.SaveChangesAsync(Cancel);
        }
    }

}
