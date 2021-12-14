using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training.DAL.Entities
{
    public class Subscribtion
    {
        public long SubscribtionId { get; set; }

        [Required]
        [MaxLength(50)]
        public string SubscribtionName { get; set; }

        [Required]
        public int SubscribtionCost { get; set; }

        [Required]
        public int WeekWorkoutHours { get; set; }

        public ICollection<Profile> Profiles { get; set; }
    }
}
