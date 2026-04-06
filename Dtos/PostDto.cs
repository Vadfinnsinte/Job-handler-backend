namespace JobHandlerAPI.DTOs
{
    // DTO used when returning post data to the client
    // It prevents exposing unnecessary database fields.
    public class PostDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string CompanyName { get; set; }

        public string Status { get; set; }

        public DateTime ApplicationDate { get; set; }
    }
}