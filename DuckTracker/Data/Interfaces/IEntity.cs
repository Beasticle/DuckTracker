using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckTracker.Data.Interfaces
{
    public interface IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }
    }
}
