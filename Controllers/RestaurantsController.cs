using Microsoft.AspNetCore.Mvc;
using RestaurantFeedbackSystem.DTOs;
using RestaurantFeedbackSystem.Interfaces;

namespace RestaurantFeedbackSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpPost]
        public async Task<ActionResult<RestaurantResponseDto>> Create(RestaurantDto restaurantDto)
        {
            var createdRestaurant = await _restaurantService.Create(restaurantDto);
            return CreatedAtAction(nameof(Get), new { id = createdRestaurant.Id }, createdRestaurant);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantResponseDto>> Get(int id)
        {
            var restaurant = await _restaurantService.Get(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantResponseDto>>> GetAll()
        {
            var restaurants = await _restaurantService.GetAll();
            return Ok(restaurants);
        }
    }
}
