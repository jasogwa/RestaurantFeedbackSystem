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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.Feedbacks)
                .WithOne(f => f.Restaurant)
                .HasForeignKey(f => f.RestaurantId);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Response)
                .WithOne(r => r.Feedback)
                .HasForeignKey<FeedbackResponse>(r => r.FeedbackId);
        }
    }
}
