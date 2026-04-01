using JobHandlerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JobHandlerAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Post> Posts  => Set<Post>();
        public DbSet<Comment> Comments => Set<Comment>();


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
