using RestaurantePOS.Dtos.DiscuntsDto;

namespace RestaurantePOS.Services.IServices
{
    public interface IDiscuntService
    {
        Task<IEnumerable<DiscuntListDto>> getAll();
        Task<DiscuntFormDto> getById(int id);
        Task<DiscuntListDto> addDiscunt(DiscuntFormDto discunt);
        Task<DiscuntListDto> updateDiscunt(DiscuntFormDto discunt);
    }
}
