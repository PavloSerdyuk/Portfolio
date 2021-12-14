using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.DAL.Entities;
using Training.BLL.Models;

namespace Training.BLL.Services.Abstractions
{
    public interface ISubscribtionService
    {
        Task<Subscribtion> GetSubscribtion(long subscribtionId);
        Task<Subscribtion> CreateSubscribtion(SubscribtionModel subscribtion);
    }
}
