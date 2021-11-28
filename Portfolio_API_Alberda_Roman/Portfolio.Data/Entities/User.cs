using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Data.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public ICollection<Representation> AssignedRepresentations { get; set; }
        public ICollection<Representation> CreatedRepresentations { get; set; }
        public ICollection<UserRepresentation> UserRepresentations { get; set; }
    }
}
