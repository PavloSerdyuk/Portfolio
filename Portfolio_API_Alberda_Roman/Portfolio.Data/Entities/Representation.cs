using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Data.Entities
{
    public class Representation : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int SpeakerId { get; set; }
        public ICollection<User> Subscribers { get; set; }
        public ICollection<UserRepresentation> UserRepresentations { get; set; }
        public User? Speaker { get; set; }
    }
}