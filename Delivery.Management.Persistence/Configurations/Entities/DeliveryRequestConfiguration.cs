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
    public class DeliveryRequestConfiguration : IEntityTypeConfiguration<DeliveryRequest>
    {
        public void Configure(EntityTypeBuilder<DeliveryRequest> builder)
        {
            builder.HasData(
               new DeliveryRequest
               {
                   Id = 1,
                   DeliveryTypeId = 1000,
                   DeliveryAllocationId = 101,
                   City = "Cracow",
                   Street = "Zielona",
                   HouseNumber = 12,
                   ZipCode = "30‑063",
                   RequestComments = "No Comment"
               },
               new DeliveryRequest
               {
                   Id = 2,
                   DeliveryTypeId = 1001,
                   DeliveryAllocationId = 102,
                   City = "Cracow",
                   Street = "Zielona",
                   HouseNumber = 12,
                   ZipCode = "30‑063",
                   RequestComments = "No Comment"
               });
        }
    }
}
