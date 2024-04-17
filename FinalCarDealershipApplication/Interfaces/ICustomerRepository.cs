using FinalCarDealershipApplication.Models;

namespace FinalCarDealershipApplication.Interfaces
{
    public interface ICustomerRepository
    {
        ICollection<Customers> GetCustomers();
        Customers GetCustomerById(string id);
        Customers GetCustomerByName(string name);
        bool CustomerExists(string customerId);
        bool CreateCustomers(Customers customer);
        bool UpdateCustomers(Customers customer);
        bool DeleteCustomer(Customers customer);
        bool Save();
    }
}
