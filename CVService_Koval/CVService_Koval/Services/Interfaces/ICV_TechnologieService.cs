using CVService_Koval.DTOS;
using CVService_Koval.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVService_Koval.Services.Interfaces
{
    public interface ICV_TechnologieService
    {
        CV GetCVById(Guid Id);
        IEnumerable<CV> GetAllCVs();
        void DeleteCV(Guid Id);
        void UpdateCV(Guid Id, CVUpdateDTO cv);
        void CreateCV(CVUpdateDTO cv);
        Technologie GetTechnologieById(Guid Id);
        IEnumerable<Technologie> GetAllTechnologies();
        void DeleteTechnologie(Guid Id);
        void UpdateTechnologie(Guid Id, TechnologieUpdateCreateDTO tech);
        void CreateTechnologie(TechnologieUpdateCreateDTO tech);
    }
}
