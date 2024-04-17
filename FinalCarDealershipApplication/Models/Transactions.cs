namespace FinalCarDealershipApplication.Models
{
    public class Transactions
    {

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? FullName { get; set; }
        public int Amount { get; set; }
        public string? TransRef { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
