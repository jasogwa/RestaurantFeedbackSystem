using RestaurantFeedbackSystem.Models;
using System.Threading.Tasks;

namespace RestaurantFeedbackSystem.Interfaces
{
    public interface IFeedbackResponseRepository
    {
        Task<FeedbackResponse> Create(FeedbackResponse feedbackResponse);
        Task<FeedbackResponse> GetById(int id);
    }
}
