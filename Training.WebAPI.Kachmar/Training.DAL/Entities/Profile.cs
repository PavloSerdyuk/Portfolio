using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training.DAL.Entities
{
    public class Profile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProfileId { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Surname { get; set; }

        [ForeignKey(nameof(SubscribtionId))]
        public Subscribtion Subscribtion { get; set; }

        public long SubscribtionId { get; set; }

        public ICollection<TrainingSession> Trainings { get; set; }
    }
}
