using Koval_Bank_And_Branches.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koval_Bank_And_Branches.Model
{
    [Serializable]
    class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Role UserRole { get; set; }
        public override string ToString()
        {
            return $"{Name} {Surname} is {UserRole.ToString()}";
        }
    }
}
