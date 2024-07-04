using RestaurantFeedbackSystem.DTOs;

namespace RestaurantFeedbackSystem.Interfaces
{
    public interface IFeedbackResponseService
    {
        Task<FeedbackResponseDetailDto> RespondToFeedback(FeedbackReplyDto feedbackResponseDto);
        Task<FeedbackResponseDetailDto> GetResponse(int id);
    }
}
