using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AutoDetailingApp.Data
{
    public class AutoDetailingDbContextFactory : IDesignTimeDbContextFactory<AutoDetailingDbContext>
    {
        public AutoDetailingDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AutoDetailingDbContext>();

            optionsBuilder.UseSqlServer("Data Source=SQL1003.site4now.net;Initial Catalog=db_aba6fd_admin;User Id=db_aba6fd_admin_admin;Password=Shikapich32!");

            return new AutoDetailingDbContext(optionsBuilder.Options);
        }
    }
}