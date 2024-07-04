using RestaurantFeedbackSystem.Models;

namespace RestaurantFeedbackSystem.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<Restaurant> Create(Restaurant restaurant);
        Task<Restaurant> GetById(int id);
        Task<IEnumerable<Restaurant>> GetAll();
    }
}
