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
                    Id = 101,
                    Warehouse = "Standard",
                    Section = "3"
                },
                new DeliveryAllocation
                {
                    Id = 102,
                    Warehouse = "Express",
                    Section = "2"
                },
                new DeliveryAllocation
                {
                    Id = 103,
                    Warehouse = "Palette",
                    Section = "5"
                },
                new DeliveryAllocation
                {
                    Id = 104,
                    Warehouse = "International By Plane",
                    Section = "14"
                },
                new DeliveryAllocation
                {
                    Id = 105,
                    Warehouse = "International by Ship",
                    Section = "45"
                });

        }
    }
}
