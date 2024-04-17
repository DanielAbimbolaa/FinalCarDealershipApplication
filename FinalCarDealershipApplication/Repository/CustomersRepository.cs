using FinalCarDealershipApplication.Data;
using FinalCarDealershipApplication.Interfaces;
using FinalCarDealershipApplication.Models;

namespace FinalCarDealershipApplication.Repository
{
    public class CustomersRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomersRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateCustomer(Customers customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Save();
       }

        public bool CreateCustomers(Customers customer)
        {
            try
            {
                _context.Customers.Add(customer);
                //_context.SaveChanges();
                 var saveChanges=Save();
                return saveChanges;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return false;
        }

        public bool CustomerExists(string customerId)
        {
            return _context.Customers.Any(c => c.customerId == customerId);
        }

        public ICollection<Customers> GetCustomers()
        {
            var customerList = _context.Customers.ToList();
            return customerList;
        }

        public Customers GetCustomerById(string id)
        {
            return _context.Customers.Where(c => c.customerId == id).FirstOrDefault();
        }

        public Customers GetCustomerByName(string name)
        {
            return _context.Customers.Where(c => c.customerName == name).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCustomers(Customers customer)
        {
            _context.Update(customer);
            return Save();
        }

        public bool DeleteCustomer(Customers customer)
        {
            _context.Remove(customer);
            return Save();
        }
    }
}
