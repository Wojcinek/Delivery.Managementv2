using Delivery.Management.MVC.Models;
using Delivery.Management.MVC.Services.Base;

namespace Delivery.Management.MVC.Contracts
{
    public interface IDeliveryAllocationService
    {
        Task<List<DeliveryAllocationVM>> GetDeliveryAllocations();
        Task<DeliveryAllocationVM> GetDeliveryAllocationDetails(int id);
        Task<Response<int>> CreateDeliveryAllocation(CreateDeliveryAllocationVM deliveryAllocation);
        Task<Response<int>> UpdateDeliveryAllocation(int id, DeliveryAllocationVM deliveryAllocation);
        Task<Response<int>> DeleteDeliveryAllocation(int id);

    }
}
