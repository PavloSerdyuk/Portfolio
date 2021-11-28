using AutoMapper;
using CVService_Koval.DbConnection;
using CVService_Koval.DTOS;
using CVService_Koval.Models;
using CVService_Koval.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVService_Koval.Services
{
    public class UserService: IUserService
    {
        private readonly IMapper Mapper;
        private KPZContext context;

        public UserService(KPZContext _context, IMapper _Mapper)
        {
            Mapper = _Mapper;
            context = _context;
        }

        public void CreateUser(UserCreateDTO User)
        {
            var item = Mapper.Map<User>(User);

            item.Id = Guid.NewGuid();

            context.Users.Add(item);

            context.SaveChanges();
        }

        public void DeleteUser(Guid Id)
        {
            var item = context.Users.FirstOrDefault(item => item.Id == Id);

            if (item != null)
            {
                context.Users.Remove(item);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<UserReadDTO> GetAllUsers()
        {
            return Mapper.Map<IEnumerable<UserReadDTO>>(context.Users.ToList());
        }

        public UserWithCVDTO GetUserById(Guid Id)
        {
            return Mapper.Map<UserWithCVDTO>(context.Users.Include(item => item.CV).FirstOrDefault(item => item.Id == Id));
        }

        public void UpdateUser(Guid Id, UserUpdateDTO User)
        {
            var item = context.Users.FirstOrDefault(item => item.Id == Id);

            if (item == null)
                throw new ArgumentNullException();

            Mapper.Map(User, item);

            context.SaveChanges();
        }
    }
}
