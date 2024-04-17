using System.ComponentModel.DataAnnotations;

namespace FinalCarDealershipApplication.Dto
{
    public class AdminDto
    {
        internal string? adminId;

        [Key]
        public string? adminName { get; set; }
        public string? email { get; set; }
        public string? phoneNumber { get; set; }
    }
}
