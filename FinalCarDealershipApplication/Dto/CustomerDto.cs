using System.ComponentModel.DataAnnotations;

namespace FinalCarDealershipApplication.Dto
{
    public class CustomerDto
    {
        internal string? customerId;

        public string? customerName { get; set; }
        public string? email { get; set; }
        public string? phoneNumber { get; set; }
    }
}
