using BusinessLogic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace M008_Authentication.Models
{
    public class MsAuthDemoDbContext : IdentityDbContext
    {
        public const string USER_ROLE = "User";
        public const string ADMIN_ROLE = "Admin";

        public MsAuthDemoDbContext()
        {
        }

        public MsAuthDemoDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Sicherstellen, dass Rollen vorhanden sind
            var roles = new List<IdentityRole>
            {
                new IdentityRole { Name = USER_ROLE, NormalizedName = "USER" },
                new IdentityRole { Name = ADMIN_ROLE, NormalizedName = "ADMIN" },
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }

#if DEBUG
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ASPNetWebApiKurs;Initial Catalog=AuthDemo;Integrated Security=True");
        }
#endif
    }
}
