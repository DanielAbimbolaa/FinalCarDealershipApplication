using System.ComponentModel.DataAnnotations;

namespace FinalCarDealershipApplication.Models
{
    public class Customers
    {
        [Key]
        public int customerId { get; set; }
        public string? customerName { get; set; }
        public string? email { get; set; }
        public int phoneNumber { get; set; }
    }
}
