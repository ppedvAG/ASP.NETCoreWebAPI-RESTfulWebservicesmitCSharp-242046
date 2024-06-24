using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic
{
    public class WebApiDbContext : DbContext
    {
        public WebApiDbContext()
        {            
        }

        public WebApiDbContext(DbContextOptions options)
            : base(options) 
        {            
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ASPNetWebApiKurs;Initial Catalog=Demo;Integrated Security=True");
        }
    }
}
