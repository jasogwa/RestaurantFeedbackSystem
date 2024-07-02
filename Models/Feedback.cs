using System.ComponentModel.DataAnnotations;

namespace RestaurantFeedbackSystem.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [Required]
        public int RestaurantId { get; set; }

        [Required]
        public string? Comment { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        // Navigation property to Restaurant
        public Restaurant? Restaurant { get; set; }

        // Optional Response
        public FeedbackResponse? Response { get; set; }
    }
}
