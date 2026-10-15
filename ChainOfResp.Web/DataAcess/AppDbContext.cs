using ChainOfResp.Web_.Entitys;

using Microsoft.EntityFrameworkCore;

namespace ChainofResp.Web.DataAccess
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-Q7KL8HK\\SQLEXPRESS;database=ChainofRespDb;integrated security=true;trustServerCertificate=true");
        }

        public DbSet<CustomerProcess> CustomerProcesses { get; set; }
    }
}