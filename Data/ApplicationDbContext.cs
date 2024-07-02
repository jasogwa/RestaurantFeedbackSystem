using Microsoft.EntityFrameworkCore;
using RestaurantFeedbackSystem.Models;

namespace RestaurantFeedbackSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<FeedbackResponse> FeedbackResponses { get; set; } 

    }
}
