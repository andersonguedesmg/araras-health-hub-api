using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Infrastructure.Persistence.Seeds
{
    public class OrderStatusSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<OrderStatus>().HasData(
                new
                {
                    Id = 1,
                    Description = "Pendente de Aprovação",
                    CreatedOn = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    IsActive = true
                },
                new
                {
                    Id = 2,
                    Description = "Pronto para Separação",
                    CreatedOn = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    IsActive = true
                },
                new
                {
                    Id = 3,
                    Description = "Em Separação",
                    CreatedOn = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    IsActive = true
                },
                new
                {
                    Id = 4,
                    Description = "Pronto para Envio/Finalização",
                    CreatedOn = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    IsActive = true
                },
                new
                {
                    Id = 5,
                    Description = "Finalizado",
                    CreatedOn = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    IsActive = true
                },
                new
                {
                    Id = 6,
                    Description = "Cancelado",
                    CreatedOn = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    IsActive = true
                }
            );
        }
    }
}
