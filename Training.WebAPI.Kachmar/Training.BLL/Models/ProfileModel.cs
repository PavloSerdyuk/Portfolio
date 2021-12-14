using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.BLL.Models
{
    public class ProfileModel
    {
        public long ProfileId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public long SubscribtionId { get; set; }
    }
}
