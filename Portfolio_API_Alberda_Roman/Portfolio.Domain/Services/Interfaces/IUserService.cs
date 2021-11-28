using Portfolio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Services.Interfaces
{
    public interface IUserService
    {
        public bool CheckUser(string userName, string password);
        public string Login(string userName, string password);

    }
}
