using RestaurantFeedbackSystem.DTOs;
using RestaurantFeedbackSystem.Interfaces;
using RestaurantFeedbackSystem.Models;

namespace RestaurantFeedbackSystem.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<RestaurantResponseDto> Create(RestaurantDto restaurantDto)
        {
            var restaurant = new Restaurant
            {
                Name = restaurantDto.Name,
                Location = restaurantDto.Location
            };

            var createdRestaurant = await _restaurantRepository.Create(restaurant);

            return new RestaurantResponseDto
            {
                Id = createdRestaurant.Id,
                Name = createdRestaurant.Name,
                Location = createdRestaurant.Location
            };
        }

        public async Task<RestaurantResponseDto> Get(int id)
        {
            var restaurant = await _restaurantRepository.GetById(id);
            if (restaurant == null) return null;

            return new RestaurantResponseDto
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Location = restaurant.Location,
                AverageRating = restaurant.Feedbacks!.Any() ? restaurant.Feedbacks!.Average(f => f.Rating) : 0,
                Feedbacks = restaurant.Feedbacks!.Select(f => new FeedbackResponseDto
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
                }).ToList()
            };
        }

        public async Task<IEnumerable<RestaurantResponseDto>> GetAll()
        {
            var restaurants = await _restaurantRepository.GetAll();
            return restaurants.Select(restaurant => new RestaurantResponseDto
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Location = restaurant.Location,
                AverageRating = restaurant.Feedbacks!.Any() ? restaurant.Feedbacks!.Average(f => f.Rating) : 0,
                Feedbacks = restaurant.Feedbacks!.Select(f => new FeedbackResponseDto
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
                }).ToList()
            }).ToList();
        }

    }
}
