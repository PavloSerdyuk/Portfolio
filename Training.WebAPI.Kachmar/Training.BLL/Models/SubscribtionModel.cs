using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.BLL.Models
{
    public class SubscribtionModel
    {
        public long SubscribtionId { get; set; }

        public string SubscribtionName { get; set; }

        public int SubscribtionCost { get; set; }

        public int WeekWorkoutHours { get; set; }
    }
}
