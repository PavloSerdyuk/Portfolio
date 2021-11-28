using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsProgram.Models
{
    public class TestNewsView
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Title can only be 250 characters long")]
        public string ArticleTitle { get; set; }
        [Required]
        public string ArticleInfo { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name can only be 50 characters long")]
        public string Author_Name { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Surname can only be 50 characters long")]
        public string Author_Surname { get; set; }
    }
}
