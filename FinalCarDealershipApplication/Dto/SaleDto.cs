using System.ComponentModel.DataAnnotations;

namespace FinalCarDealershipApplication.Dto
{
    public class SaleDto
    {
        [Required]
        public string CarId { get; set; }
        public string CustomerId { get; set; }
    }
}
