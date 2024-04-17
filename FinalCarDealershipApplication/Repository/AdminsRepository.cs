using FinalCarDealershipApplication.Data;
using FinalCarDealershipApplication.Interfaces;
using FinalCarDealershipApplication.Models;

namespace FinalCarDealershipApplication.Repository
{
    public class AdminsRepository : IAdminRepository
    {
        private readonly DataContext _context;

        public AdminsRepository(DataContext context)
        {
            _context = context;
        }
        public bool AdminExists(string adminId)
        {
            return _context.Admins.Any(a => a.adminId == adminId);
        }

        public bool CreateAdmin(Admins admin)
        {
            throw new NotImplementedException();
        }

        public bool CreateAdmins(Admins admin)
        {
            _context.Add(admin);
            _context.SaveChanges();
            return Save();
        }

        public bool DeleteAdmin(Admins admin)
        {
            _context.Remove(admin);
            return Save();
        }

        public ICollection<Admins> GetAdmin()
        {
            return _context.Admins.OrderBy(a => a.adminId).ToList();
        }

        public Admins GetAdmin(string id)
        {
            return _context.Admins.Where(a => a.adminId == id).FirstOrDefault();
        }

        public Admins GetAdmins(string name)
        {
            return _context.Admins.Where(a => a.adminName == name).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateAdmin(Admins admin)
        {
            _context.Update(admin);
            return Save();
        }
    }
}
