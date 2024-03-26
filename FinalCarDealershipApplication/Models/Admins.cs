using System.ComponentModel.DataAnnotations;

namespace FinalCarDealershipApplication.Models
{
    public class Admins
    {
        [Key]
        public int adminId { get; set; }
        public string? adminName { get; set; }
        public string? email { get; set; }
        public int phoneNumber { get; set; }

    }
}
