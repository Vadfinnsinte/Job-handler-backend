using JobHandlerAPI.Data;
using JobHandlerAPI.DTOs;
using JobHandlerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JobHandlerAPI.Services
{
    // The controller calls this service instead of accessing the database directly.
    public class PostService
    {
        private readonly AppDbContext _context;

        // Dependency injection of the database context
        public PostService(AppDbContext context)
        {
            _context = context;
        }

        // Returns all posts from the database.
        // The Post entities are mapped to PostDto objects before being returned.
        // This prevents exposing the full database model to the client.
        public async Task<List<PostDto>> GetAllPosts()
        {
            return await _context.Posts
                .Select(p => new PostDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    CompanyName = p.CompanyName,
                    Status = p.Status,
                    ApplicationDate = p.ApplicationDate
                })
                .ToListAsync();
        }

        // Retrieves a single post by its ID.
        public async Task<Post?> GetPost(Guid id)
        {
            return await _context.Posts.FindAsync(id);
        }

        // Returns all posts created by a specific user
        public async Task<List<Post>> GetPostsByUser(string userId)
        {
            return await _context.Posts
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }

        // Creates a new post in the database.
        // The userId is retrieved from the JWT token in the controller.
        public async Task<Post> CreatePost(CreatePostDto dto, string userId)
        {
            var post = new Post
            {
                Id = Guid.NewGuid(),
                UserId = userId,

                Title = dto.Title,
                CompanyName = dto.CompanyName,
                Link = dto.Link,
                Status = dto.Status,
                AdText = dto.AdText,

                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
                ApplicationDate = dto.ApplicationDate
            };

            _context.Posts.Add(post);

            // Saves the new post to the database
            await _context.SaveChangesAsync();

            return post;
        }

        // Updates an existing post in the database.
        public async Task<bool> UpdatePost(Guid id, UpdatePostDto dto)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
                return false;

            post.Title = dto.Title;
            post.CompanyName = dto.CompanyName;
            post.Link = dto.Link;
            post.Status = dto.Status;
            post.AdText = dto.AdText;
            post.ApplicationDate = dto.ApplicationDate;

            // Update timestamp
            post.Updated = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }

        // Admin deletes any post
        public async Task<bool> DeletePostAdmin(Guid id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
                return false;

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return true;
        }

        // User deletes their own post
        public async Task<bool> DeleteOwnPost(Guid id, string userId)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
                return false;

            if (post.UserId != userId)
                return false;

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return true;
        }


    }
}