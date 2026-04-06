using JobHandlerAPI.DTOs.Comment;
using JobHandlerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobHandlerAPI.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentService _commentService;

        public CommentController(CommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var result = await _commentService.GetAllCommentsAsync();

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(Guid id)
        {
            var result = await _commentService.GetCommentByIdAsync(id);

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        [HttpGet("post/{postId}")]
        public async Task<IActionResult> GetCommentsByPostId(Guid postId)
        {
            var result = await _commentService.GetCommentsByPostIdAsync(postId);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentCreateDto dto)
        {
            var result = await _commentService.CreateCommentAsync(dto);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(Guid id, CommentUpdateDto dto)
        {
            var result = await _commentService.UpdateCommentAsync(id, dto);

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            var result = await _commentService.DeleteCommentAsync(id);

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }
    }
}
