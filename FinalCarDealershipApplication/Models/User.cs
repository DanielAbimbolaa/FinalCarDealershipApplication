using System.ComponentModel.DataAnnotations;

namespace FinalCarDealershipApplication.Models
{
    public class User
    {
        [Key]
        public string? userId { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public string? email { get; set; }
        public string? phoneNumber { get; set; }
        public bool isAdmin { get; set; }

    }
}
