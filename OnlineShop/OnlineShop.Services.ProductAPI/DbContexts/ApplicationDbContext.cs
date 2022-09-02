using Microsoft.EntityFrameworkCore;
using OnlineShop.Services.ProductAPI.Models;

namespace OnlineShop.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
