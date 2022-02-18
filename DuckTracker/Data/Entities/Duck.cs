using DuckTracker.Data.Interfaces;

namespace DuckTracker.Data.Entities
{
    public class Duck : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Details { get; set; }
    }
}
