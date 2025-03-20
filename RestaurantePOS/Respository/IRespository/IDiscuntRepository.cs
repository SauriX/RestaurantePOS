using RestaurantePOS.Domain.Configuration;

namespace RestaurantePOS.Respository.IRespository
{
    public interface IDiscuntRepository
    {
        Task<IEnumerable<Discunts>> getAll();
        Task<Discunts>getById(int id);
        Task addDiscunt(Discunts discunt);
        Task updateDiscunt(Discunts discunt);
        Task<bool> isDuplicate(Discunts discunts);
    }
}
