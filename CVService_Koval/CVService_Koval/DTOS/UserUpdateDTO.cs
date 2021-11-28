using CVService_Koval.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVService_Koval.DTOS
{
    public class UserUpdateDTO
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public Guid? CVId { get; set; }
    }
}
