using RestaurantFeedbackSystem.DTOs;

namespace RestaurantFeedbackSystem.Interfaces
{
    public interface IFeedbackService
    {
        Task<FeedbackResponseDto> SubmitFeedback(FeedbackDto feedbackDto);
        Task<FeedbackResponseDto> GetFeedback(int id);
        Task<IEnumerable<FeedbackResponseDto>> GetFeedbacksForRestaurant(int restaurantId);
    }
}
