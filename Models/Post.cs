namespace JobHandlerAPI.Models
{
    public class Post
    {
        public Guid Id { get; set; } 
        public string UserId { get; set; }

        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string Link { get; set; }

        public string Status { get; set; }

        public string AdText { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; } 
        public DateTime ApplicationDate { get; set; } 


    }
}
