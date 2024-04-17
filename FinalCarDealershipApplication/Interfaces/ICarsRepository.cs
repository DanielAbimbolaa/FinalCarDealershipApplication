using FinalCarDealershipApplication.Models;

namespace FinalCarDealershipApplication.Interfaces
{
    public interface ICarsRepository
    {
        ICollection<Cars> GetCars();

        Cars GetCar(string id);
        Cars GetCars(string name);
        bool CarsExists(string id);
       // bool CarsExist(int carID);
       // bool CarsExist(string make);
        bool CreateCar(Cars car);
        bool UpdateCar(Cars car);
        bool DeleteCar(Cars car);
        bool Save();
    }
}
