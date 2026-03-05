using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Infrastructure.Persistence.Seeds
{
    public static class FacilitySeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Facility>().HasData(
                new
                {
                    Id = 1,
                    Name = "Secretária Municipal da Saúde - Dr. João Geraldo Noronha",
                    Cnes = "6345921",
                    CreatedOn = DateTime.SpecifyKind(new DateTime(2025, 01, 02, 08, 35, 14), DateTimeKind.Utc),
                    IsActive = true
                }
            );
        }
    }
}
