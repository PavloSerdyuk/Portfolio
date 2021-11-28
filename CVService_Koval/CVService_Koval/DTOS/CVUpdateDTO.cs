using CVService_Koval.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVService_Koval.DTOS
{
    public class CVUpdateDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public double Expirience { get; set; }
        public string BachelorDegree { get; set; }
        public ICollection<CVTechnologie> CVTechnologies { get; set; }
    }
}
