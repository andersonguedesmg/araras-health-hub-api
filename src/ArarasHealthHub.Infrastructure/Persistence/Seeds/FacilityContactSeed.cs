using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Infrastructure.Persistence.Seeds
{
    public class FacilityContactSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Facility>().OwnsOne(f => f.Contact).HasData(
                new
                {
                    FacilityId = 1,
                    Email = "saude@araras.sp.gov.br",
                    Phone = "(19) 3543-1522"
                }
            );
        }
    }
}
