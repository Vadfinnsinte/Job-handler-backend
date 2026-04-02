namespace JobHandlerAPI.DTOs.Comment
{
    public class CommentReadDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public Guid PostId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}