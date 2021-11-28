using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CVService_Koval.Models
{
    public class CVTechnologie
    {
        public Guid Id { get; set; }
        [ForeignKey("Technologie")]
        public Guid TechnologieId { get; set; }
        public Technologie Technologie { get; set; }
        [ForeignKey("CV")]
        public Guid CVId { get; set; }
        public CV CV { get; set; }
    }
}
