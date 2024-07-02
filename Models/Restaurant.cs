using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantFeedbackSystem.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Location { get; set; }

        // Navigation property to Feedbacks
        public ICollection<Feedback>? Feedbacks { get; set; }
    }
}
