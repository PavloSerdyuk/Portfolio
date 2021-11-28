using System;
using System.Collections.Generic;
using System.Text;

namespace CVService_Koval.DTOS
{
    public class UserReadDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }
    }
}
