using Entities.Models;

namespace WebAPI.Business
{
    public interface IKitapService
    {
        Task<List<Kitap>> GetAllAsync();
        Task<Kitap> GetByIdAsync(int id);
        Task AddAsync(Kitap kitap);
        Task UpdateAsync(Kitap kitap);
        Task DeleteAsync(int id);
    }
}
