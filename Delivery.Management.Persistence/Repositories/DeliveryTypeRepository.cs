using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Management.Application.Contracts.Presistence;
using Delivery.Management.Domain;

namespace Delivery.Management.Persistence.Repositories
{
    public class DeliveryTypeRepository : GenericRepository<DeliveryType>, IDeliveryTypeRepository
    {
        private readonly DeliveryManagementDbContext _dbContext;

        public DeliveryTypeRepository(DeliveryManagementDbContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;

        }
    }
}
