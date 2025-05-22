using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Business;

namespace WebAPI.API
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Kullanici")]
    public class OduncController : ControllerBase
    {
        private readonly IOduncService _oduncService;

        public OduncController(IOduncService oduncService)
        {
            _oduncService = oduncService;
        }

        // Kitap ödünç al
        [HttpPost("al/{kitapId}")]
        public async Task<IActionResult> OduncAl(int kitapId)
        {
            var kullaniciAdi = User.Identity?.Name;
            var result = await _oduncService.OduncAlAsync(kullaniciAdi, kitapId);
            return Ok(result);
        }

        // Kitap iade et
        [HttpPost("iade/{kitapId}")]
        public async Task<IActionResult> IadeEt(int kitapId)
        {
            var kullaniciAdi = User.Identity?.Name;
            var result = await _oduncService.IadeEtAsync(kullaniciAdi, kitapId);
            return Ok(result);
        }

        // Kendi ödünç geçmişini gör
        [HttpGet("gecmis")]
        public async Task<IActionResult> Gecmis()
        {
            var kullaniciAdi = User.Identity?.Name;
            var liste = await _oduncService.GetUserHistoryAsync(kullaniciAdi);
            return Ok(liste);
        }
    }
}
