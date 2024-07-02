using Microsoft.EntityFrameworkCore;
using RestaurantFeedbackSystem.Data;
using RestaurantFeedbackSystem.Interfaces;
using RestaurantFeedbackSystem.Models;

namespace RestaurantFeedbackSystem.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly ApplicationDbContext _context;

        public RestaurantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Restaurant> Create(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();
            return restaurant;
        }

        public async Task<Restaurant> GetById(int id)
        {
            return await _context.Restaurants
                .Include(r => r.Feedbacks!)
                .ThenInclude(f => f.Response!)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Restaurant>> GetAll()
        {
            return await _context.Restaurants
                .Include(r => r.Feedbacks!)
                .ThenInclude(f => f.Response!)
                .ToListAsync();
        }
    }
}
