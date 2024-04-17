using System.ComponentModel.DataAnnotations;

namespace FinalCarDealershipApplication.Models
{
    public class Customers
    {
        [Key]
        public string customerId { get; set; } = Guid.NewGuid().ToString();
        public string? customerName { get; set; }
        public string? email { get; set; }
        public string? phoneNumber { get; set; }
    }
}
