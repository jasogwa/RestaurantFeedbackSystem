using RestaurantFeedbackSystem.DTOs;


namespace RestaurantFeedbackSystem.Interfaces
{
    public interface IRestaurantService
    {
        Task<RestaurantResponseDto> Create(RestaurantDto restaurantDto);
        Task<RestaurantResponseDto> Get(int id);
        Task<IEnumerable<RestaurantResponseDto>> GetAll();
    }
}
