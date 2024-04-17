namespace FinalCarDealershipApplication.Dto
{
    public class CarDto
    {
        internal string? carID;

        public string? Make { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public string? Colour { get; set; }
        public int Mileage { get; set; }
        public int Price { get; set; }
        public string? Transmission { get; set; }
        public string? Features { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsAvailable { get; set; }
        public int NumberAvailabe { get; set; }
    }
}
