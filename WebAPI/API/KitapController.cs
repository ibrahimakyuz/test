using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Business;

namespace WebAPI.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class KitapController : ControllerBase
    {
        private readonly IKitapService _kitapService;

        public KitapController(IKitapService kitapService)
        {
            _kitapService = kitapService;
        }

        // Herkes görebilir
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var kitaplar = await _kitapService.GetAllAsync();
            return Ok(kitaplar);
        }

        // Sadece Admin erişebilir
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(Kitap kitap)
        {
            await _kitapService.AddAsync(kitap);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, Kitap kitap)
        {
            if (id != kitap.Id) return BadRequest();
            await _kitapService.UpdateAsync(kitap);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _kitapService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var kitap = await _kitapService.GetByIdAsync(id);
            if (kitap == null)
                return NotFound();

            return Ok(kitap);
        }
    }
}
