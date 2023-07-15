using Delivery.Management.MVC.Models;
using Delivery.Management.MVC.Services.Base;

namespace Delivery.Management.MVC.Contracts
{
    public interface IDeliveryRequestService
    {
        Task<List<DeliveryRequestVM>> GetDeliveryRequests();
        Task<DeliveryRequestVM> GetDeliveryRequestsDetails(int id);
        Task<Response<int>> CreateDeliveryRequest(CreateDeliveryRequestVM deliveryRequest);
        Task<Response<int>> UpdateDeliveryRequest(int id, DeliveryRequestVM deliveryRequest);
        Task<Response<int>> DeleteDeliveryRequest(int id);
    }
}
