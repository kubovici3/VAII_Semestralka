using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VAII_Semestralka.Models;

namespace VAII_Semestralka.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Produkt> Produkty { get; set; }
        public DbSet<Plosny_material> Materialy { get; set; }
        public DbSet<Udaje> Udaje { get; set; } 
        public DbSet<IdentityUser> Pouzivatel { get; set; }
        public  DbSet<Rezervacia> Rezervacia { get; set; }
    }
}
