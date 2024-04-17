using FinalCarDealershipApplication.Data;
using FinalCarDealershipApplication.Models;

namespace FinalCarDealershipApplication
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if(!dataContext.Cars.Any())
            {
                var Cars = new List<Cars>()
                {
                    new Cars()
                     {
                Make = "Honda",
                Model = "Civic",
                Year = 2023,
                Colour = "Silver",
                Mileage = 10000,
                Price = 25000,
                Transmission = "Automatic",
                Features = "Sunroof, Leather Seats",
                Image = "https://example.com/civic.jpg",
                IsAvailable = true
            },
            new Cars
            {
                Make = "Toyota",
                Model = "Camry",
                Year = 2022,
                Colour = "Black",
                Mileage = 25000,
                Price = 30000,
                Transmission = "Automatic",
                Features = "Navigation, Heated Seats",
                Image = "https://example.com/camry.jpg",
                IsAvailable = true
            },
                };
                dataContext.Cars.AddRange(Cars);
                dataContext.SaveChanges();
            }
        }
    }
}
