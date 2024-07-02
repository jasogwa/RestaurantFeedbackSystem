using RestaurantFeedbackSystem.DTOs;
using System.Threading.Tasks;

namespace RestaurantFeedbackSystem.Interfaces
{
    public interface IFeedbackResponseService
    {
        Task<FeedbackResponseDetailDto> RespondToFeedback(FeedbackReplyDto feedbackResponseDto);
        Task<FeedbackResponseDetailDto> GetResponse(int id);
    }
}
