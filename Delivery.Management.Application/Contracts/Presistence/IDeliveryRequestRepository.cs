using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Management.Domain;

namespace Delivery.Management.Application.Contracts.Presistence
{
    public interface IDeliveryRequestRepository : IGenericRepository<DeliveryRequest>
    {
        Task<DeliveryRequest> GetDeliveryRequestWithDetails(int id);

        Task<List<DeliveryRequest>> GetDeliveryRequestWithDetails();
    }
}
