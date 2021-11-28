using System;
using System.Collections.Generic;

namespace CVService_Koval.Models
{
    public class Technologie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<CVTechnologie> CVTechnologies { get; set; }
    }
}
