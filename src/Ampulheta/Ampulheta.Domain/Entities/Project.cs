namespace Ampulheta.Domain.Entities
{
    public class Project : EntityBase
    {
        public string Name { get; private set; }
        public string Note { get; private set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Time> Times { get; set; }

    }
}
