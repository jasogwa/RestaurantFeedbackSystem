using Microsoft.AspNetCore.Mvc;
using RestaurantFeedbackSystem.DTOs;
using RestaurantFeedbackSystem.Interfaces;
using RestaurantFeedbackSystem.Models;

namespace RestaurantFeedbackSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbacksController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpPost]
        public async Task<ActionResult<FeedbackResponseDto>> SubmitFeedback(FeedbackDto feedbackDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdFeedback = await _feedbackService.SubmitFeedback(feedbackDto);
            return CreatedAtAction(nameof(GetFeedback), new { id = createdFeedback.Id }, createdFeedback);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackResponseDto>> GetFeedback(int id)
        {
            var feedback = await _feedbackService.GetFeedback(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return Ok(feedback);
        }

        [HttpGet("restaurant/{restaurantId}")]
        public async Task<ActionResult<IEnumerable<FeedbackResponseDto>>> GetFeedbacksForRestaurant(int restaurantId)
        {
            var feedbacks = await _feedbackService.GetFeedbacksForRestaurant(restaurantId);
            return Ok(feedbacks);
        }

    }
}
