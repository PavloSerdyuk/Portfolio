using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.DAL.Entities;
using Training.BLL.Models;


namespace Training.BLL.Services.Abstractions
{
    public interface ITrainerService
    {
        Task<Trainer> CreateTrainer(TrainerModel trainer);
    }
}
