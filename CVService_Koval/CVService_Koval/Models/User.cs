using CVService_Koval.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVService_Koval.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(250)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(32)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(32)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(32)]
        public string UserName { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z]{8,32}$")]
        public string Password { get; set; }
        [MaxLength(250)]
        public string Status { get; set; }
        [Required]
        public Role UserRole { get; set; }
        public CV CV { get; set; }

        [ForeignKey("CV")]
        public Guid? CVId { get; set; }
    }
}
