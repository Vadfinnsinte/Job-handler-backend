using Microsoft.AspNetCore.SignalR;

namespace JobHandlerAPI.Models
{
    public class Comment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string UserId { get; set; }

        public Guid PostId { get; set; }

        public string Text { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;

        public ApplicationUser User { get; set; }

        public Post Post { get; set; }



    }
}
