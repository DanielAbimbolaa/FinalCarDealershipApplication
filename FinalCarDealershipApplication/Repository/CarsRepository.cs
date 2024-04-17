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

        public bool CarsExists(string id)
        {
            return _context.Cars.Any(c => c.carID == id);
        }

        //public bool CarsExists(string id)
        //{
        //    return _context.Cars.Any(c => c.carID == id);
        //}

        //public bool CarsExist(string carID)
        //{
        //    return _context.Cars.Any(c => c.carID == carID);
        //}

        public bool CreateCar(Cars car)
        {
            _context.Add(car);
            _context.SaveChanges();
            return Save();
        }

        public bool DeleteCar(Cars car)
        {
            _context.Remove(car);
            return Save();
        }


        public Cars GetCars(string id)
        {
            return _context.Cars.Where(c => c.carID == id).FirstOrDefault();
        }

        public Cars GetCar(string name)
        {
            return _context.Cars.Where(c => c.Make == name).FirstOrDefault();
        }

        public ICollection<Cars> GetCars()
        {
            var carList = _context.Cars.ToList();
            return carList;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCar(Cars car)
        {
            _context.Update(car);
            return Save();
        }
    }
}