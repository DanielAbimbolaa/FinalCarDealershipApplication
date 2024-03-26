using FinalCarDealershipApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FinalCarDealershipApplication.Data
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Cars> Cars { get; set; } 
        public DbSet<User> Users { get; set; }
        public DbSet<Admins> Admins { get; set; }
        public DbSet<Customers>  Customers { get; set; }
        public DbSet<Sales> Sales { get; set; }

        

    }
}
