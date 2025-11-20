using Microsoft.EntityFrameworkCore;
namespace Gestion_de_stock.Models
{
    public class StockContext : DbContext
    {
        public StockContext(DbContextOptions<StockContext> options) : base(options) { }

        public DbSet<Produit> Produits { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Demande> Demandes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}