using RestaurantFeedbackSystem.Models;

namespace RestaurantFeedbackSystem.Interfaces
{
    public interface IFeedbackResponseRepository
    {
        Task<FeedbackResponse> Create(FeedbackResponse feedbackResponse);
        Task<FeedbackResponse> GetById(int id);
    }
}
