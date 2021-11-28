using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CVService_Koval.Models
{
    public class CV
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public double Expirience { get; set; }
        public string BachelorDegree { get; set; }
        public ICollection<CVTechnologie> CVTechnologies { get; set; }
    }
}
