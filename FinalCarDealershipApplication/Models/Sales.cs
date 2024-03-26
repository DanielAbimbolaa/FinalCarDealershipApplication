using System.ComponentModel.DataAnnotations;

namespace FinalCarDealershipApplication.Models
{
    public class Sales
    {
        [Key]
        public int saleId { get; set; }
        public Cars? Cars { get; set; }
        public Customers? Customers { get; set; }   
        public DateTime saleDate { get; set; }
    }
}
