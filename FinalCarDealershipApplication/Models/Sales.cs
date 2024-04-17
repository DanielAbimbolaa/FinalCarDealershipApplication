using System.ComponentModel.DataAnnotations;

namespace FinalCarDealershipApplication.Models
{
    public class Sales
    {

        [Key]
        public string? saleId { get; set; } = Guid.NewGuid().ToString();
        public Cars? Cars { get; set; }
        public Customers? Customers { get; set; }
        public DateTime saleDate { get; set; } = DateTime.Now;
    }
}
