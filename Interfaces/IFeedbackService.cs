using RestaurantFeedbackSystem.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantFeedbackSystem.Interfaces
{
    public interface IFeedbackService
    {
        Task<FeedbackResponseDto> SubmitFeedback(FeedbackDto feedbackDto);
        Task<FeedbackResponseDto> GetFeedback(int id);
        Task<IEnumerable<FeedbackResponseDto>> GetFeedbacksForRestaurant(int restaurantId);
    }
}
