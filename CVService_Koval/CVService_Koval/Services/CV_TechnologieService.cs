using AutoMapper;
using CVService_Koval.DbConnection;
using CVService_Koval.DTOS;
using CVService_Koval.Models;
using CVService_Koval.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVService_Koval.Services
{
    public class CV_TechnologieService : ICV_TechnologieService
    {
        private readonly IMapper Mapper;
        private KPZContext context;

        public CV_TechnologieService(KPZContext _context, IMapper _Mapper)
        {
            Mapper = _Mapper;
            context = _context;
        }
        public void CreateCV(CVUpdateDTO cv)
        {
            var item = Mapper.Map<CV>(cv);

            item.Id = Guid.NewGuid();

            context.CVs.Add(item);

            context.SaveChanges();
        }

        public void CreateTechnologie(TechnologieUpdateCreateDTO tech)
        {
            var item = Mapper.Map<Technologie>(tech);

            item.Id = Guid.NewGuid();

            context.Technologies.Add(item);

            context.SaveChanges();
        }

        public void DeleteCV(Guid Id)
        {
            var item = context.CVs.FirstOrDefault(item => item.Id == Id);

            if (item != null)
            {
                context.CVs.Remove(item);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void DeleteTechnologie(Guid Id)
        {
            var item = context.Technologies.FirstOrDefault(item => item.Id == Id);

            if (item != null)
            {
                context.Technologies.Remove(item);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<CV> GetAllCVs()
        {
            return context.CVs.ToList();
        }

        public IEnumerable<Technologie> GetAllTechnologies()
        {
            return context.Technologies.ToList();
        }

        public CV GetCVById(Guid Id)
        {
            return context.CVs.FirstOrDefault(item => item.Id == Id);
        }

        public Technologie GetTechnologieById(Guid Id)
        {
            return context.Technologies.FirstOrDefault(item => item.Id == Id);
        }

        public void UpdateCV(Guid Id, CVUpdateDTO cv)
        {
            var item = context.CVs.FirstOrDefault(item => item.Id == Id);

            if (item == null)
                throw new ArgumentNullException();

            Mapper.Map(cv, item);

            context.SaveChanges();
        }

        public void UpdateTechnologie(Guid Id, TechnologieUpdateCreateDTO tech)
        {
            var item = context.Technologies.FirstOrDefault(item => item.Id == Id);

            if (item == null)
                throw new ArgumentNullException();

            Mapper.Map(tech, item);

            context.SaveChanges();
        }
    }
}
