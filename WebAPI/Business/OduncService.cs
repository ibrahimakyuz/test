using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Business
{
    public class OduncService : IOduncService
    {
        private readonly LibraryDbContext _context;

        public OduncService(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<List<OduncVerilen>> GetUserHistoryAsync(string kullaniciAdi)
        {
            var user = await _context.Kullanicilar.FirstOrDefaultAsync(x => x.KullaniciAdi == kullaniciAdi);
            return await _context.OduncVerilenler
                .Include(x => x.Kitap)
                .Where(x => x.KullaniciId == user.Id)
                .ToListAsync();
        }

        public async Task<string> OduncAlAsync(string kullaniciAdi, int kitapId)
        {
            var user = await _context.Kullanicilar.FirstOrDefaultAsync(x => x.KullaniciAdi == kullaniciAdi);
            var kitap = await _context.Kitaplar.FindAsync(kitapId);

            if (kitap == null) return "Kitap bulunamadı";
            if (kitap.Stok <= 0) return "Kitap stokta yok";

            kitap.Stok--;

            var odunc = new OduncVerilen
            {
                KullaniciId = user.Id,
                KitapId = kitap.Id,
                AlisTarihi = DateTime.Now,
                IadeEdildi = false
            };

            _context.OduncVerilenler.Add(odunc);
            await _context.SaveChangesAsync();

            return "Kitap başarıyla ödünç alındı.";
        }

        public async Task<string> IadeEtAsync(string kullaniciAdi, int kitapId)
        {
            var user = await _context.Kullanicilar.FirstOrDefaultAsync(x => x.KullaniciAdi == kullaniciAdi);
            var odunc = await _context.OduncVerilenler
                .FirstOrDefaultAsync(x => x.KullaniciId == user.Id && x.KitapId == kitapId && !x.IadeEdildi);

            if (odunc == null) return "İade edilecek kitap bulunamadı.";

            odunc.IadeEdildi = true;
            odunc.IadeTarihi = DateTime.Now;

            var kitap = await _context.Kitaplar.FindAsync(kitapId);
            kitap.Stok++;

            await _context.SaveChangesAsync();
            return "Kitap başarıyla iade edildi.";
        }
    }
}
