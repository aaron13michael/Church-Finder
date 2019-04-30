using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Church_Finder.Models
{
    public class Church_FinderContext : DbContext
    {
        public Church_FinderContext (DbContextOptions<Church_FinderContext> options)
            : base(options)
        {
        }

        public DbSet<Church_Finder.Models.Location> Location { get; set; }
    }
}
