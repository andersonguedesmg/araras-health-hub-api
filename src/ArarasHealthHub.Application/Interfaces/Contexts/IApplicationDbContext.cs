using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Interfaces.Contexts
{
    public interface IApplicationDbContext
    {
        DbSet<ApplicationUser> Users { get; set; }
        DbSet<Facility> Facility { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
