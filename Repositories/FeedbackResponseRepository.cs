using Microsoft.EntityFrameworkCore;
using RestaurantFeedbackSystem.Data;
using RestaurantFeedbackSystem.Interfaces;
using RestaurantFeedbackSystem.Models;

namespace RestaurantFeedbackSystem.Repositories
{
    public class FeedbackResponseRepository : IFeedbackResponseRepository
    {
        private readonly ApplicationDbContext _context;

        public FeedbackResponseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FeedbackResponse> Create(FeedbackResponse feedbackResponse)
        {
            _context.FeedbackResponses.Add(feedbackResponse);
            await _context.SaveChangesAsync();
            return feedbackResponse;
        }

        public async Task<FeedbackResponse> GetById(int id)
        {
            return await _context.FeedbackResponses
                .Include(fr => fr.Feedback)
                .FirstOrDefaultAsync(fr => fr.Id == id);
        }
    }
}
