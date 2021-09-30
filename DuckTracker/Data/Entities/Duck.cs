using DuckTracker.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckTracker.Data.Entities
{
    public class Duck : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }
    }
}
