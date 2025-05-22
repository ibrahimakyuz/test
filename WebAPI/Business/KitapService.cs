using Entities.Models;
using WebAPI.DataAccess;

namespace WebAPI.Business
{
    public class KitapService : IKitapService
    {
        private readonly IGenericRepository<Kitap> _kitapRepo;

        public KitapService(IGenericRepository<Kitap> kitapRepo)
        {
            _kitapRepo = kitapRepo;
        }

        public async Task<List<Kitap>> GetAllAsync() => await _kitapRepo.GetAllAsync();

        public async Task<Kitap> GetByIdAsync(int id) => await _kitapRepo.GetByIdAsync(id);

        public async Task AddAsync(Kitap kitap)
        {
            await _kitapRepo.AddAsync(kitap);
            await _kitapRepo.SaveAsync();
        }

        public async Task UpdateAsync(Kitap kitap)
        {
            _kitapRepo.Update(kitap);
            await _kitapRepo.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var kitap = await _kitapRepo.GetByIdAsync(id);
            if (kitap != null)
            {
                _kitapRepo.Delete(kitap);
                await _kitapRepo.SaveAsync();
            }
        }
    }
}
