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
    public class DeliveryTypeConfiguration : IEntityTypeConfiguration<DeliveryType>
    {
        public void Configure(EntityTypeBuilder<DeliveryType> builder)
        {
            builder.HasData(
                new DeliveryType
                {
                    Id = 10,
                    Name = "Unloading"
                },
                new DeliveryType
                {
                    Id = 11,
                    Name = "Preparing"
                },
                new DeliveryType
                {
                    Id = 12,
                    Name = "Sent"
                });
        }
    }
}
