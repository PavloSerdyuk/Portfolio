using Koval_Bank_And_Branches.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koval_Bank_And_Branches.Model
{
    [Serializable]
    class Contract
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ManagerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ValidUntil { get; set; }
        public decimal Amount { get; set; }
        public ContractType ContractType { get; set; }
        public double ProcentIncreasement { get; set; }
    }
}
