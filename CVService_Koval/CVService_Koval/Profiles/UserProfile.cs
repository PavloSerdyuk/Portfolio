using AutoMapper;
using CVService_Koval.DTOS;
using CVService_Koval.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVService_Koval.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateDTO, User>();
            CreateMap<UserUpdateDTO, User>();
            CreateMap<User, UserUpdateDTO>();
            CreateMap<User, UserReadDTO>();
            CreateMap<User, UserWithCVDTO>();
        }
    }
}
