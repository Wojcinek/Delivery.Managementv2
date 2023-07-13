using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Management.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Delivery.Management.Persistence.Configurations.Entities
{
    public class DeliveryAllocationConfiguration : IEntityTypeConfiguration<DeliveryAllocation>
    {
        public void Configure(EntityTypeBuilder<DeliveryAllocation> builder) 
        {
            builder.HasData(
                new DeliveryAllocation
                {
                    Id = 1,
                    Warehouse = "Warehouse 1",
                    Section = "1"
                },
                new DeliveryAllocation
                {
                    Id = 2,
                    Warehouse = "Warehouse 2",
                    Section = "2"
                });

        }
    }
}
