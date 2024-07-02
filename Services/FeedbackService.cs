using RestaurantFeedbackSystem.DTOs;
using RestaurantFeedbackSystem.Interfaces;
using RestaurantFeedbackSystem.Models;

namespace RestaurantFeedbackSystem.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IFeedbackResponseRepository _feedbackResponseRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository, IFeedbackResponseRepository feedbackResponseRepository)
        {
            _feedbackRepository = feedbackRepository;
            _feedbackResponseRepository = feedbackResponseRepository;
        }

        public async Task<FeedbackResponseDto> SubmitFeedback(FeedbackDto feedbackDto)
        {
            var feedback = new Feedback
            {
                RestaurantId = feedbackDto.RestaurantId,
                Comment = feedbackDto.Comment,
                Rating = feedbackDto.Rating
            };

            var createdFeedback = await _feedbackRepository.Create(feedback);

            return new FeedbackResponseDto
            {
                Id = createdFeedback.Id,
                RestaurantId = createdFeedback.RestaurantId,
                Comment = createdFeedback.Comment,
                Rating = createdFeedback.Rating
            };
        }

        public async Task<FeedbackResponseDto> GetFeedback(int id)
        {
            var feedback = await _feedbackRepository.GetById(id);
            if (feedback == null) return null;
            

            return new FeedbackResponseDto
            {
                Id = feedback.Id,
                RestaurantId = feedback.RestaurantId,
                Comment = feedback.Comment,
                Rating = feedback.Rating,
                Response = feedback.Response != null ? new FeedbackResponseDetailDto
                {
                    Id = feedback.Response.Id,
                    FeedbackId = feedback.Response.FeedbackId,
                    ResponseText = feedback.Response.ResponseText
                } : null
            };
        }

        public async Task<IEnumerable<FeedbackResponseDto>> GetFeedbacksForRestaurant(int restaurantId)
        {
            var feedbacks = await _feedbackRepository.GetByRestaurantId(restaurantId);
            
            return feedbacks.Select(f => new FeedbackResponseDto
            {
                Id = f.Id,
                RestaurantId = f.RestaurantId,
                Comment = f.Comment,
                Rating = f.Rating,
                Response = f.Response != null ? new FeedbackResponseDetailDto
                {
                    Id = f.Response.Id,
                    FeedbackId = f.Response.FeedbackId,
                    ResponseText = f.Response.ResponseText
                } : null
            }).ToList();

        }
    }
}
