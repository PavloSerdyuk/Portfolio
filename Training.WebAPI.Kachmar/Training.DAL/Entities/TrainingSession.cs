
namespace Training.DAL.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class TrainingSession
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TrainingId { get; set; }

        [Required]
        public DateTime TrainingTime { get; set; }

        [Required]
        public string TrainerName { get; set; }

        [ForeignKey(nameof(ProfileId))]
        public Profile Profile { get; set; }

        public long ProfileId { get; set; }
    }
}
