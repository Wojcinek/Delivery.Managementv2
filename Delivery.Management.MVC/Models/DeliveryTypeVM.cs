using System.ComponentModel.DataAnnotations;

namespace Delivery.Management.MVC.Models
{
    public class DeliveryTypeVM : CreateDeliveryTypeVM
    {
        public int Id { get; set; }
    }

    public class CreateDeliveryTypeVM
    {
        [Required]
        public string Name { get; set; }
    }
}
