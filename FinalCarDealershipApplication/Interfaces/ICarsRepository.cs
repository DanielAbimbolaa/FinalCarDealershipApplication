using FinalCarDealershipApplication.Models;

namespace FinalCarDealershipApplication.Interfaces
{
    public interface ICarsRepository
    {
        ICollection<Cars> GetCars();

        Cars GetCars (int id);
        Cars GetCars (string name);
        bool CarsExists(int id);
        bool CarsExixts(int carID);
        bool CarsExixts(string make);
        object GetCar(string model);
    }
}
