using Delivery.Management.MVC.Models;
using Delivery.Management.MVC.Services.Base;

namespace Delivery.Management.MVC.Contracts
{
    public interface IDeliveryTypeService
    {
        Task<List<DeliveryTypeVM>> GetDeliveryTypes();
        Task<DeliveryTypeVM> GetDeliveryTypesDetails(int id);
        Task<Response<int>> CreateDeliveryType(CreateDeliveryTypeVM deliveryType);
        Task<Response<int>> UpdateDeliveryType(int id, DeliveryTypeVM deliveryType);
        Task<Response<int>> DeleteDeliveryType(int id);
    }
}
