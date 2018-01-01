using System.Data.Entity;

namespace Sklep.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("Sklep")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}