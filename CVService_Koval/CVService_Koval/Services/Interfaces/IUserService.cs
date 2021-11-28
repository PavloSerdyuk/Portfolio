using CVService_Koval.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVService_Koval.Services.Interfaces
{
    public interface IUserService
    {
        UserWithCVDTO GetUserById(Guid Id);
        IEnumerable<UserReadDTO> GetAllUsers();
        void DeleteUser(Guid Id);
        void UpdateUser(Guid Id, UserUpdateDTO User);
        void CreateUser(UserCreateDTO User);
    }
}
