namespace JobHandlerAPI.DTOs.Comment
{
    public class CommentCreateDto
    {
        public string Text { get; set; }
        public string UserId { get; set; }
        public Guid PostId { get; set; }
    }
}