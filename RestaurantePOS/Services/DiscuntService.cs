using RestaurantePOS.Dtos.DiscuntsDto;
using RestaurantePOS.Helpers;
using RestaurantePOS.Mappers;
using RestaurantePOS.Respository.IRespository;
using RestaurantePOS.Services.IServices;
using System.Net;

namespace RestaurantePOS.Services
{
    public class DiscuntService : IDiscuntService
    {
        private readonly IDiscuntRepository _discuntRepository;
        public DiscuntService(IDiscuntRepository discuntRepository) { 
               _discuntRepository = discuntRepository;
        }
        public async Task<DiscuntListDto> addDiscunt(DiscuntFormDto discunt)
        {
            var discuntNew = discunt.toModel();
            var isDupicate = await _discuntRepository.isDuplicate(discuntNew);
            if (isDupicate) {
                throw new CustomException(HttpStatusCode.Conflict ,"Descuento ya agregado");
            }
            await _discuntRepository.addDiscunt(discuntNew);
            return discuntNew.toDiscuntList();
        }

        public async Task<IEnumerable<DiscuntListDto>> getAll()
        {
           
            var discunts = await _discuntRepository.getAll();
            return discunts.toDiscuntList();
        }

        public async Task<DiscuntFormDto> getById(int id)
        {
            var discunt = await _discuntRepository.getById(id);
            return discunt.toDiscuntForm();
        }

        public async Task<DiscuntListDto> updateDiscunt(DiscuntFormDto discunt)
        {

            var oldDiscunt = await _discuntRepository.getById(discunt.DiscuntId);
            var discuntUpdate = discunt.toModel(oldDiscunt);
            var isDuplicate = await _discuntRepository.isDuplicate(discuntUpdate);
            if (isDuplicate)
            {
                throw new CustomException(HttpStatusCode.Conflict, "Descuento ya agregado");
            }
            await _discuntRepository.updateDiscunt(discuntUpdate);
            return discuntUpdate.toDiscuntList() ;
            
        }
    }
}
