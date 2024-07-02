using System.ComponentModel.DataAnnotations;

namespace RestaurantFeedbackSystem.DTOs
{
    public class FeedbackDto
    {
        public int RestaurantId { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Comment is required")]
        public string? Comment { get; set; } 
    }

    public class FeedbackResponseDto
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public FeedbackResponseDetailDto? Response { get; set; }
    }

    public class FeedbackResponseDetailDto
    {
        public int Id { get; set; }
        public int FeedbackId { get; set; }
        public string? ResponseText { get; set; }
    }
}

