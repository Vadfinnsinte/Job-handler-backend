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
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "1"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "2"
                }
            );

      //      var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "u1",
                    UserName = "admin@test.com",
                    NormalizedUserName = "ADMIN@TEST.COM",
                    Email = "admin@test.com",
                    NormalizedEmail = "ADMIN@TEST.COM",
                    EmailConfirmed = true,
                    Name = "Admin User",
                    EmploymentStatus = true,
                    Created = new DateTime(2024, 4, 2, 14, 30, 0, DateTimeKind.Utc),
                    PasswordHash = "AQAAAAIAAYagAAAAEC7G//5lR9tL3LqUr/GKrFYgxc6L5GKz87BvdCzb07dQLNkCgtwkGbHefQGihmQD5w==",
                    SecurityStamp = "0334c1a6-afb3-4f2d-b8cd-352667da8222",
                    ConcurrencyStamp = "9859207d-9062-4022-a1fe-bf38de9b8888"
                },
                new ApplicationUser
                {
                    Id = "u2",
                    UserName = "user1@test.com",
                    NormalizedUserName = "USER1@TEST.COM",
                    Email = "user1@test.com",
                    NormalizedEmail = "USER1@TEST.COM",
                    EmailConfirmed = true,
                    Name = "User One",
                    EmploymentStatus = false,
                    Created = DateTime.Parse("2024-04-02 14:30:00"),
                    PasswordHash = "AQAAAAIAAYagAAAAEC7G//5lR9tL3LqUr/GKrFYgxc6L5GKz87BvdCzb07dQLNkCgtwkGbHefQGihmQD5w==",
                    SecurityStamp = "0334c1a6-afb3-4f2d-b8cd-352667da8000",
                    ConcurrencyStamp = "9859207d-9062-4022-a1fe-bf38de9b0000"
                },
                new ApplicationUser
                {
                    Id = "u3",
                    UserName = "user2@test.com",
                    NormalizedUserName = "USER2@TEST.COM",
                    Email = "user2@test.com",
                    NormalizedEmail = "USER2@TEST.COM",
                    EmailConfirmed = true,
                    Name = "User Two",
                    EmploymentStatus = false,
                    Created = DateTime.Parse("2024-04-02 14:30:00"),
                    PasswordHash = "AQAAAAIAAYagAAAAEC7G//5lR9tL3LqUr/GKrFYgxc6L5GKz87BvdCzb07dQLNkCgtwkGbHefQGihmQD5w==",
                    SecurityStamp = "0334c1a6-afb3-4f2d-b8cd-352667da8221",
                    ConcurrencyStamp = "9859207d-9062-4022-a1fe-bf38de9b0195"
                }
            );

            // Koppla users till roller
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "u1", RoleId = "1" }, // Admin
                new IdentityUserRole<string> { UserId = "u2", RoleId = "2" },
                new IdentityUserRole<string> { UserId = "u3", RoleId = "2" }
            );

            builder.Entity<Post>().HasData(

            // User u1 (Admin)
            new Post
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                UserId = "u1",
                Title = "Backend Developer",
                CompanyName = "Company A",
                Link = "https://example.com/job1",
                Status = "Applied",
                AdText = "Job ad text here",
                Created = new DateTime(2024, 4, 2, 14, 30, 0, DateTimeKind.Utc),
                Updated = new DateTime(2024, 4, 2, 14, 30, 0, DateTimeKind.Utc),
                ApplicationDate = new DateTime(2024, 4, 2, 14, 30, 0, DateTimeKind.Utc),
            },
            new Post
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                UserId = "u1",
                Title = "Fullstack Developer",
                CompanyName = "Company B",
                Link = "https://example.com/job2",
                Status = "Pending",
                AdText = "Another job ad",
                Created = DateTime.Parse("2024-04-02 14:30:00"),
                Updated = DateTime.Parse("2024-04-02 14:30:00"),
                ApplicationDate = DateTime.Parse("2024-04-02 14:30:00"),
            },

            // User u2
            new Post
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222221"),
                UserId = "u2",
                Title = "Frontend Developer",
                CompanyName = "Company C",
                Link = "https://example.com/job3",
                Status = "Applied",
                AdText = "Frontend job",
                Created = DateTime.Parse("2024-04-02 14:30:00"),
                Updated = DateTime.Parse("2024-04-02 14:30:00"),
                ApplicationDate = DateTime.Parse("2024-04-02 14:30:00"),
            },
            new Post
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                UserId = "u2",
                Title = "React Developer",
                CompanyName = "Company D",
                Link = "https://example.com/job4",
                Status = "Rejected",
                AdText = "React job",
                Created = DateTime.Parse("2024-04-02 14:30:00"),
                Updated = DateTime.Parse("2024-04-02 14:30:00"),
                ApplicationDate = DateTime.Parse("2024-04-02 14:30:00"),
            },

            // User u3
            new Post
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333331"),
                UserId = "u3",
                Title = "DevOps Engineer",
                CompanyName = "Company E",
                Link = "https://example.com/job5",
                Status = "Pending",
                AdText = "DevOps job",
                Created = DateTime.Parse("2024-04-02 14:30:00"),
                Updated = DateTime.Parse("2024-04-02 14:30:00"),
                ApplicationDate = DateTime.Parse("2024-04-02 14:30:00")
            },
            new Post
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333332"),
                UserId = "u3",
                Title = "Cloud Engineer",
                CompanyName = "Company F",
                Link = "https://example.com/job6",
                Status = "Applied",
                AdText = "Cloud job",
                Created = DateTime.Parse("2024-04-02 14:30:00"),
                Updated = DateTime.Parse("2024-04-02 14:30:00"),
                ApplicationDate = DateTime.Parse("2024-04-02 14:30:00")
            }
        );
        }
    }
}
