using Microsoft.EntityFrameworkCore;
using RestaurantePOS.context;
using RestaurantePOS.Domain.Configuration;
using RestaurantePOS.Domain.Users;
using RestaurantePOS.Respository.IRespository;

namespace RestaurantePOS.Respository
{
    public class DiscuntRepository:IDiscuntRepository
    {
        private readonly ContextDb _contextDb;
        public DiscuntRepository(ContextDb contextDb) { 
            _contextDb = contextDb;
        }

        public async Task addDiscunt(Discunts discunt)
        {
            _contextDb.Discunts.Add(discunt);
            await _contextDb.SaveChangesAsync();
        }

        public async Task<IEnumerable<Discunts>> getAll()
        {
            var discunts = await _contextDb.Discunts.ToArrayAsync();
            return discunts;
        }

        public async Task<Discunts> getById(int id)
        {
            var discunt = await _contextDb.Discunts.FirstOrDefaultAsync(disc=> disc.DiscuntId==id);
            return discunt;
        }

        public async Task<bool> isDuplicate(Discunts discunts)
        {
            var isDuplicate = await _contextDb.Discunts.AnyAsync(discunt => discunt.DiscuntId != discunts.DiscuntId && discunt.DiscuntName == discunts.DiscuntName);
            return isDuplicate;
        }

        public async Task updateDiscunt(Discunts discunt)
        {
            _contextDb.Discunts.Update(discunt);
            await _contextDb.SaveChangesAsync();
        }
    }
}
