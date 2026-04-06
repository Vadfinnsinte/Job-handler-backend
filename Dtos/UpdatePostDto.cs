namespace JobHandlerAPI.DTOs
{
    // DTO used when updating a post.
    // Fields such as Id, UserId, Created and Updated
    // cannot be modified by the user.
    public class UpdatePostDto
    {
        public string Title { get; set; }

        public string CompanyName { get; set; }

        public string Link { get; set; }

        public string Status { get; set; }

        public string AdText { get; set; }

        public DateTime ApplicationDate { get; set; }
    }
}