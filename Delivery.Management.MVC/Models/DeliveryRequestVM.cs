using System.ComponentModel.DataAnnotations;

namespace Delivery.Management.MVC.Models
{
    public class DeliveryRequestVM : CreateDeliveryRequestVM
    {
        public int Id { get; set; }
    }

    public class CreateDeliveryRequestVM
    {
        [Required]
        public int DeliveryTypeId { get; set; }
        [Required]
        public int DeliveryAllocationId { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int HouseNumber { get; set; }
        [Required]
        public string ZipCode { get; set; }
        public string RequestComments { get; set; }
    }

}
