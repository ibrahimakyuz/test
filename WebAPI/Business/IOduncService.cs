using Entities.Models;

namespace WebAPI.Business
{
    public interface IOduncService
    {
        Task<List<OduncVerilen>> GetUserHistoryAsync(string kullaniciAdi);
        Task<string> OduncAlAsync(string kullaniciAdi, int kitapId);
        Task<string> IadeEtAsync(string kullaniciAdi, int kitapId);
    }
}
