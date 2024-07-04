using RestaurantFeedbackSystem.Models;

namespace RestaurantFeedbackSystem.Interfaces
{
    public interface IFeedbackRepository
    {
        Task<Feedback> Create(Feedback feedback);
        Task<Feedback> GetById(int id);
        Task<IEnumerable<Feedback>> GetByRestaurantId(int restaurantId);
    }
}
