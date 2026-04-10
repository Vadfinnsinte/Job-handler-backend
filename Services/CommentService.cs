using JobHandlerAPI.Data;
using JobHandlerAPI.DTOs.Comment;
using JobHandlerAPI.Helpers;
using JobHandlerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace JobHandlerAPI.Services
{
    public class CommentService
    {
        private readonly AppDbContext _context;

        public CommentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<List<CommentReadDto>>> GetAllCommentsAsync()
        {
            var comments = await _context.Comments.ToListAsync();

            var result = comments.Select(comment => new CommentReadDto
            {
                Id = comment.Id,
                UserId = comment.UserId,
                PostId = comment.PostId,
                Text = comment.Text,
                CreationDate = comment.CreationDate,
                UpdatedDate = comment.UpdatedDate
            }).ToList();

            return Result<List<CommentReadDto>>.Success(result);
        }

        

        public async Task<Result<List<CommentReadDto>>> GetCommentsByPostIdAsync(Guid postId)
        {
            var comments = await _context.Comments
                .Where(c => c.PostId == postId)
                .ToListAsync();

            var result = comments.Select(comment => new CommentReadDto
            {
                Id = comment.Id,
                UserId = comment.UserId,
                PostId = comment.PostId,
                Text = comment.Text,
                CreationDate = comment.CreationDate,
                UpdatedDate = comment.UpdatedDate
            }).ToList();

            return Result<List<CommentReadDto>>.Success(result);
        }

        public async Task<Result<CommentReadDto>> CreateCommentAsync(CommentCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Text))
                return Result<CommentReadDto>.Failure("Text is required");

            if (dto.Text.Length > 500)
                return Result<CommentReadDto>.Failure("Text too long");

            var postExists = await _context.Posts.AnyAsync(p => p.Id == dto.PostId);
            if (!postExists)
                return Result<CommentReadDto>.Failure("Post not found");

            var userExists = await _context.Users.AnyAsync(u => u.Id == dto.UserId);
            if (!userExists)
                return Result<CommentReadDto>.Failure("User not found");

            var comment = new Comment
            {
                Id = Guid.NewGuid(),
                UserId = dto.UserId,
                PostId = dto.PostId,
                Text = dto.Text,
                CreationDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            var result = new CommentReadDto
            {
                Id = comment.Id,
                UserId = comment.UserId,
                PostId = comment.PostId,
                Text = comment.Text,
                CreationDate = comment.CreationDate,
                UpdatedDate = comment.UpdatedDate
            };

            return Result<CommentReadDto>.Success(result);
        }

        public async Task<Result<bool>> UpdateCommentAsync(Guid id, CommentUpdateDto dto)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);

            if (comment == null)
                return Result<bool>.Failure("Comment not found");

            if (string.IsNullOrWhiteSpace(dto.Text))
                return Result<bool>.Failure("Text is required");

            if (dto.Text.Length > 500)
                return Result<bool>.Failure("Text too long");


            comment.Text = dto.Text;
            comment.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Result<bool>.Success(true);
        }

        public async Task<Result<bool>> DeleteCommentAsync(Guid id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);

            if (comment == null)
                return Result<bool>.Failure("Comment not found");

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return Result<bool>.Success(true);
        }
    }
}