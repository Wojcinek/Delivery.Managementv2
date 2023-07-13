using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Management.Application.Contracts.Presistence;
using Delivery.Management.Domain;

namespace Delivery.Management.Persistence.Repositories
{
    public class DeliveryAllocationRepository : GenericRepository<DeliveryAllocation>, IDeliveryAllocationRepository
    {
        private readonly DeliveryManagementDbContext _dbContex;

        public DeliveryAllocationRepository(DeliveryManagementDbContext dbContext) : base(dbContext)
        {
            _dbContex = dbContext;
        }
    }
}
