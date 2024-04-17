using FinalCarDealershipApplication.Data;
using FinalCarDealershipApplication.Interfaces;
using FinalCarDealershipApplication.Models;

namespace FinalCarDealershipApplication.Repository
{
    public class SalesRepository : ISaleRepository
    {
        private readonly DataContext _context;

        public SalesRepository(DataContext context)
        {
            _context = context;
        }   

        public Customers GetCustomers(string id)
        {
            return _context.Customers.Where(c => c.customerId == id).FirstOrDefault();
        }

        public bool CreateSales(Sales saleMap)
        {
            try
            {
                _context.Sales.Add(saleMap);
                _context.SaveChanges();
                return Save();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                //throw;
            }
            return false;
        }


        public ICollection<Sales> GetSales()
        {
            return _context.Sales.OrderBy(s => s.saleId).ToList();
        }

        public Sales GetSales(string id)
        {
            return _context.Sales.Where(s => s.saleId == id).FirstOrDefault();
        }

        public Sales GetSale(DateTime date)
        {
            return _context.Sales.Where(s => s.saleDate == date).FirstOrDefault();
        }

        public bool SaleExists(string saleId)
        {
            return _context.Sales.Any(s => s.saleId == saleId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateSales(Sales sale)
        {
            _context.Update(sale);
            return Save();
        }

        public bool DeleteSale(Sales sale)
        {
            _context.Remove(sale);
            return Save();
        }
    }
}