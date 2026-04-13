using JobHandlerAPI.DTOs.Comment;
using JobHandlerAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobHandlerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentService _commentService;

        public CommentController(CommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllComments()
        {
            var result = await _commentService.GetAllCommentsAsync();

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }


        [HttpGet("{postId}")]
        [Authorize]
        public async Task<IActionResult> GetCommentsByPostId(Guid postId)
        {
            var result = await _commentService.GetCommentsByPostIdAsync(postId);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateComment(CommentCreateDto dto)
        {
            var result = await _commentService.CreateCommentAsync(dto);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateComment(Guid id, CommentUpdateDto dto)
        {
            var result = await _commentService.UpdateCommentAsync(id, dto);

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            var result = await _commentService.DeleteCommentAsync(id);

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }
    }
}

