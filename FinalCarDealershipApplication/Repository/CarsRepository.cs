using FinalCarDealershipApplication.Data;
using FinalCarDealershipApplication.Interfaces;
using FinalCarDealershipApplication.Models;

namespace PokemonReviewApp.Repository
{
    public class CarsRepository : ICarsRepository
    {
        private readonly DataContext _context;

        public CarsRepository(DataContext context)
        {
            _context = context;
        }

        public bool CarsExists(int Year)
        {
            return _context.Cars.Any(c => c.Year == Year);
        }

        public bool CarsExixts(int Year)
        {
            return _context.Cars.Any(c => c.Year == Year);
        }

        public bool CarsExixts(string Make)
        {
            return _context.Cars.Any(c => c.Make == Make);
        }

        public object GetCar(string model)
        {
            throw new NotImplementedException();
        }

        public ICollection<Cars> GetCars()
        {
            return _context.Cars.OrderBy(c => c.carID).ToList();
        }

        public Cars GetCars(int Year)
        {
            return _context.Cars.Where(c => c.Year == Year).FirstOrDefault();
        }

        public Cars GetCars(string name)
        {
            return _context.Cars.Where(c => c.Make == name).FirstOrDefault();
        }

    }
}