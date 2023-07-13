using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Management.Domain;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Management.Persistence
{
    public class DeliveryManagementDbContext : DbContext
    {
        public DeliveryManagementDbContext(DbContextOptions<DeliveryManagementDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DeliveryManagementDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<DeliveryRequest> DeliveryRequests { get; set; }
        public DbSet<DeliveryType> DeliveryTypes { get; set; }
        public DbSet<DeliveryAllocation> DeliveryAllocations { get; set; }
    }
}
