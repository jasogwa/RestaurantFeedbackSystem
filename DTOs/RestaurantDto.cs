namespace RestaurantFeedbackSystem.DTOs
{
    public class RestaurantDto
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
    }

    public class RestaurantResponseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public double AverageRating { get; set; }
        public List<FeedbackResponseDto>? Feedbacks { get; set; }
    }
}



