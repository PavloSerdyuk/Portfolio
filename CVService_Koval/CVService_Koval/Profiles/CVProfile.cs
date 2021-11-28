﻿using AutoMapper;
using CVService_Koval.DTOS;
using CVService_Koval.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVService_Koval.Profiles
{
    public class CVProfile: Profile
    {
        public CVProfile()
        {
            CreateMap<CVUpdateDTO, CV>();
            CreateMap<CV, CVUpdateDTO>();
        }
    }
}
