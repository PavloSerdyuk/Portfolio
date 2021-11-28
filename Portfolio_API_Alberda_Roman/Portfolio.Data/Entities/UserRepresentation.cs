namespace Portfolio.Data.Entities
{
    public class UserRepresentation : IEntity
    {
        public int RepresentationId { get; set; }
        public int UserId { get; set; }
        public Representation? Representation { get; set; }
        public User? User { get; set; }
    }
}
