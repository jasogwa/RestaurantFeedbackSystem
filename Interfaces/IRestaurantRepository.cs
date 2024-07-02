using RestaurantFeedbackSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantFeedbackSystem.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<Restaurant> Create(Restaurant restaurant);
        Task<Restaurant> GetById(int id);
        Task<IEnumerable<Restaurant>> GetAll();
    }
}
