namespace JobHandlerAPI.Models
{
    public class Post
    {
        public Guid Id = Guid.NewGuid();
        public string UserId { get; set; }

        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string Link { get; set; }

        public string Status { get; set; }

        public string AdText { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime Updated { get; set; } = DateTime.UtcNow;
        public DateTime ApplicationDate { get; set; } = DateTime.UtcNow;


    }
}
