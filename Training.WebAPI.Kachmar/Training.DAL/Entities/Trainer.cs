
namespace Training.DAL.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Trainer
    {
        public long TrainerId { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        public int Rate { get; set; }
    }
}
