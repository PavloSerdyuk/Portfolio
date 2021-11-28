using AutoMapper;
using NewsProgram.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsProgram.Models
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<News, TestNewsView>(MemberList.Destination);
        }
    }
}
