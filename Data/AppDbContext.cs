using Microsoft.EntityFrameworkCore;
using VAII_Semestralka.Models;

namespace VAII_Semestralka.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Produkt> Produkty { get; set; }
        public DbSet<Plosny_material> Materialy { get; set; }
    }
}
