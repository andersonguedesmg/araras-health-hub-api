using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Models;
using Microsoft.EntityFrameworkCore;

namespace araras_health_hub_api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Destination> Destination { get; set; }
        public DbSet<DestinationUser> DestinationUser { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<User> User { get; set; }
    }
}
