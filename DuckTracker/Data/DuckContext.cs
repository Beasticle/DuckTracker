using DuckTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckTracker.Data
{
    public class DuckContext : DbContext
    {
        
        public DuckContext(DbContextOptions<DuckContext> options) : base(options)
        {

        }

        public DbSet<Duck> Name { get; set; }
        public DbSet<Duck> Location { get; set; }

 
    }
}
