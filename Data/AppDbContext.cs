using JobHandlerAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobHandlerAPI.Data
{
    public class AppDbContext :
    IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(
        DbContextOptions<AppDbContext> options)
        : base(options)
        { }
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Comment> Comments => Set<Comment>();

        protected override void OnModelCreating(
        ModelBuilder builder)
        {
            base.OnModelCreating(builder); // Important!

            // Seed roles
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "User",
                    NormalizedName = "USER"
                }
            );
        }
    }
}
