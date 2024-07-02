using Microsoft.EntityFrameworkCore;
using RestaurantFeedbackSystem.Data;
using RestaurantFeedbackSystem.Interfaces;
using RestaurantFeedbackSystem.Models;

namespace RestaurantFeedbackSystem.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ApplicationDbContext _context;

        public FeedbackRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Feedback> Create(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            return feedback;
        }

        public async Task<Feedback> GetById(int id)
        {
            return await _context.Feedbacks
                .Include(f => f.Response)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Feedback>> GetByRestaurantId(int restaurantId)
        {
            return await _context.Feedbacks
                .Include(f => f.Response)
                .Where(f => f.RestaurantId == restaurantId)
                .ToListAsync();
        }
    }
}
