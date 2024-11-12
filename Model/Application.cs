using Microsoft.EntityFrameworkCore;

namespace ProductsManagementApplication.Model
{
    public class Application : DbContext
    {
        public Application(DbContextOptions<Application> options) : base(options) { }

        public DbSet<Products> Products { get; set; }
    }
}
