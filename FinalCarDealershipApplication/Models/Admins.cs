using System.ComponentModel.DataAnnotations;

namespace FinalCarDealershipApplication.Models
{
    public class Admins
    {
        [Key]
        public string adminId { get; set; } = Guid.NewGuid().ToString();
        public string? adminName { get; set; }
        public string? email { get; set; }
        public string phoneNumber { get; set; }

    }
}
