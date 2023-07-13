using System.ComponentModel.DataAnnotations;

namespace Delivery.Management.MVC.Models
{
    public class DeliveryAllocationVM : CreateDeliveryAllocationVM
    {
        public int Id { get; set; }
    }

    public class CreateDeliveryAllocationVM
    {
        [Required]
        public string Warehouse { get; set; }

        [Required]
        public string Section { get; set; }
    }

}