namespace JobHandlerAPI.DTOs.Post
{
    public class PostCreateDto
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string Link { get; set; }
        public string Status { get; set; }
        public string AdText { get; set; }
        public DateTime ApplicationDate { get; set; }
    }
}
