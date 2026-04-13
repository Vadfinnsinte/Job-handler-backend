namespace JobHandlerAPI.DTOs.Comment
{
    public class CommentCreateDto
    {
        public string UserId { get; set; } = string.Empty;
        public Guid PostId { get; set; }
        public string Text { get; set; } = string.Empty; 
      
    }
}