namespace JobHandlerAPI.DTOs.Comment
{
    public class CommentReadDto
    {
        public Guid Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public Guid PostId { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}