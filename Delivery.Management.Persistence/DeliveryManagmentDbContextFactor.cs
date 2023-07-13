using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Delivery.Management.Persistence
{
    public class DeliveryManagmentDbContextFactor : IDesignTimeDbContextFactory<DeliveryManagementDbContext>
    {
        public DeliveryManagementDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<DeliveryManagementDbContext>();
            var connectionString = configuration.GetConnectionString("DeliveryManagementConnectionString");

            builder.UseSqlServer(connectionString);

            return new DeliveryManagementDbContext(builder.Options);
        }
    }

}