using FinalCarDealershipApplication.Models;

namespace FinalCarDealershipApplication.Interfaces
{
    public interface IAdminRepository
    {
        ICollection<Admins> GetAdmin();
        Admins GetAdmin(string id);
        Admins GetAdmins(string name);
        bool AdminExists(string adminId);
        bool CreateAdmins(Admins admin);
        bool UpdateAdmin(Admins admin);
        bool DeleteAdmin(Admins admin);
        bool Save();
    }
}
