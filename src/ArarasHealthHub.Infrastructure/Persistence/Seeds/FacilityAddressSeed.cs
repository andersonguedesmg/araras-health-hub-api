using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Infrastructure.Persistence.Seeds
{
    public static class FacilityAddressSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Facility>().OwnsOne(f => f.Address).HasData(
                new
                {
                    FacilityId = 1,
                    Cep = "13601-111",
                    Street = "Rua Campos Sales",
                    Complement = "",
                    Number = "33",
                    Neighborhood = "Jardim Belvedere",
                    City = "Araras",
                    State = "SP"
                }
            );
        }
    }
}
