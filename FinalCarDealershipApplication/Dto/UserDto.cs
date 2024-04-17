using System.ComponentModel.DataAnnotations;

namespace FinalCarDealershipApplication.Dto
{
    public class UserDto
    {
        internal string? userId;

        public string? Name { get; set; }
        public string? email { get; set; }
        public string? phoneNumber { get; set; }
        public bool isAdmin { get; set; }
    }
}
