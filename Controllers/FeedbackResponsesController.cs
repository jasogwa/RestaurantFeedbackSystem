using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using RestaurantFeedbackSystem.Models;
using RestaurantFeedbackSystem.Interfaces;
using RestaurantFeedbackSystem.DTOs;
using System.Net;

namespace RestaurantFeedbackSystem.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackResponseController : ControllerBase
    {
        private readonly IFeedbackResponseService _feedbackResponseService;

        public FeedbackResponseController(IFeedbackResponseService feedbackResponseService)
        {
            _feedbackResponseService = feedbackResponseService;
        }

        [HttpPost]
        public async Task<ActionResult<FeedbackResponseDetailDto>> RespondToFeedback(FeedbackReplyDto feedbackReplyDto)
        {
            var createdResponse = await _feedbackResponseService.RespondToFeedback(feedbackReplyDto);
            return CreatedAtAction(nameof(GetResponse), new { id = createdResponse.Id }, createdResponse);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackResponseDetailDto>> GetResponse(int id)
        {
            var response = await _feedbackResponseService.GetResponse(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

    }
}
