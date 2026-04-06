using JobHandlerAPI.DTOs;
using JobHandlerAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobHandlerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        //Dependency injection of PostService
        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            _postService = postService;
        }

        //GET-endpoint, only admins can see all posts in the system
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postService.GetAllPosts();
            return Ok(posts);
        }

        // Returns only the posts created by the logged-in user
        [HttpGet("my-posts")]
        [Authorize]
        public async Task<IActionResult> GetMyPosts()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var posts = await _postService.GetPostsByUser(userId);

            return Ok(posts);
        }

        //POST-endpoint to create a new post, accessible only to authenticated users
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePost(CreatePostDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var post = await _postService.CreatePost(dto, userId);

            return Ok(post);
        }

        //PUT-endpoint to update an existing post by its ID, accessible only to authenticated users
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdatePost(Guid id, UpdatePostDto dto)
        {
            var updated = await _postService.UpdatePost(id, dto);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        //DELETE-endpoint to delete a post by its ID, accessible only to users with the "Admin" role
        [HttpDelete("admin/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePostAdmin(Guid id)
        {
            var deleted = await _postService.DeletePostAdmin(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }

        //DELETE-endpoint, users can delete their own posts
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteOwnPost(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var deleted = await _postService.DeleteOwnPost(id, userId);

            if (!deleted)
                return Forbid();

            return NoContent();
        }
    }
}