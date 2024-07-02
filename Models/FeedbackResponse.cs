using System.ComponentModel.DataAnnotations;

namespace RestaurantFeedbackSystem.Models
{
    public class FeedbackResponse
    {
        public int Id { get; set; }

        [Required]
        public int FeedbackId { get; set; }

        [Required]
        public string? ResponseText { get; set; }

        // Navigation property for feedback
        public Feedback? Feedback { get; set; } 

    }
}
