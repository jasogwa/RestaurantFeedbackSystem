using RestaurantFeedbackSystem.DTOs;
using RestaurantFeedbackSystem.Interfaces;
using RestaurantFeedbackSystem.Models;

namespace RestaurantFeedbackSystem.Services
{

    public class FeedbackResponseService : IFeedbackResponseService
    {
        private readonly IFeedbackResponseRepository _feedbackResponseRepository;
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackResponseService(IFeedbackResponseRepository feedbackResponseRepository, IFeedbackRepository feedbackRepository)
        {
            _feedbackResponseRepository = feedbackResponseRepository;
            _feedbackRepository = feedbackRepository;
        }

        public async Task<FeedbackResponseDetailDto> RespondToFeedback(FeedbackReplyDto feedbackReplyDto)
        {
            var feedback = await _feedbackRepository.GetById(feedbackReplyDto.FeedbackId);
            if (feedback == null) { return null; }

            var feedbackResponse = new FeedbackResponse
            {
                FeedbackId = feedbackReplyDto.FeedbackId,
                ResponseText = feedbackReplyDto.ResponseText
            };

            var createdResponse = await _feedbackResponseRepository.Create(feedbackResponse);

            return new FeedbackResponseDetailDto
            {
                Id = createdResponse.Id,
                FeedbackId = createdResponse.FeedbackId,
                ResponseText = createdResponse.ResponseText
            };
        }

        public async Task<FeedbackResponseDetailDto> GetResponse(int id)
        {
            var response = await _feedbackResponseRepository.GetById(id);
            if (response == null)
            {
                return null;
            }

            return new FeedbackResponseDetailDto
            {
                Id = response.Id,
                FeedbackId = response.FeedbackId,
                ResponseText = response.ResponseText
            };
        }
    }

}
