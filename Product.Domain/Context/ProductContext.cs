using Microsoft.EntityFrameworkCore;



namespace Product.Domain.Context
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options):base(options)
        {

        }

        public DbSet<ProductDetail> ProductDetail { get; set; }
        public DbSet<PriceDetail> PriceDetail { get; set; }
    }
}
