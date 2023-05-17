using LaMiaPizzeria.Models;
using Microsoft.EntityFrameworkCore;

namespace LaMiaPizzeria.Database
{
    public class PizzaContext : DbContext
    {
        public DbSet<PizzaModel> Pizzas { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=PizzaDb;Integrated Security=True;TrustServerCertificate=True");
    }
    }

    
}
