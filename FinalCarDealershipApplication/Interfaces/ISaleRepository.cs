using FinalCarDealershipApplication.Dto;
using FinalCarDealershipApplication.Models;

namespace FinalCarDealershipApplication.Interfaces
{
    public interface ISaleRepository
    {
        Customers GetCustomers(string id);
        ICollection<Sales> GetSales();
        Sales GetSales(string id);
        Sales GetSale(DateTime date);
        bool SaleExists(string saleId);
        bool CreateSales(Sales sale);
        bool UpdateSales(Sales sale);
        bool DeleteSale(Sales sale);
        bool Save();
    }
}
