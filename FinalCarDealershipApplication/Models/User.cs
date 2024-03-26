using System.ComponentModel.DataAnnotations;

namespace FinalCarDealershipApplication.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; } 
        public string? Name { get; set; }
        public string? email { get; set; }
        public int phoneNumber { get; set; }
        public bool isAdmin { get; set; }

    }
}
