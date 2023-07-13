using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Management.Application.Contracts.Presistence;
using Delivery.Management.Domain;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Management.Persistence.Repositories
{
    public class DeliveryRequestRepository : GenericRepository<DeliveryRequest>, IDeliveryRequestRepository
    {
        private readonly DeliveryManagementDbContext _dbContext;
        public DeliveryRequestRepository(DeliveryManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DeliveryRequest> GetDeliveryRequestWithDetails(int id)
        {
            var deliveryRequest = await _dbContext.DeliveryRequests
                .Include(q => q.DeliveryType)
                .Include(p => p.DeliveryAllocation)
                .FirstOrDefaultAsync(x => x.Id == id);

            return deliveryRequest;
        }

        public async Task<List<DeliveryRequest>> GetDeliveryRequestWithDetails()
        {
            var deliveryRequest = await _dbContext.DeliveryRequests
                .Include(q => q.DeliveryType)
                .Include(p => p.DeliveryAllocation)
                .ToListAsync();

            return deliveryRequest;
        }
    }
}
