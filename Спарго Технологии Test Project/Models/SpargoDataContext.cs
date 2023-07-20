using Microsoft.EntityFrameworkCore;
using Spargo_Technology_Test_Project.Models.Data_models;

namespace Spargo_Technology_Test_Project.Models
{
    public class SpargoDataContext : DbContext
    {
        public SpargoDataContext(DbContextOptions<SpargoDataContext> options) : base(options) { }

        public DbSet<Batch> Batches { get; set; }
        public DbSet<Pharmacy> Pharmacy { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
    }
}
