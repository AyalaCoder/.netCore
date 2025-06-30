using final_project.BL;
using final_project.models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace final_project.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class GiftController : ControllerBase
    {
        private readonly IGiftService _giftService;

        public GiftController(IGiftService giftService)
        {
            _giftService = giftService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GiftDTO>>> GetAll()
        {
            return await _giftService.GetAllGiftsAsync();
        }

 
        [HttpGet("{id}")]
        public async Task<ActionResult<GiftDTO>> GetById(int id)
        {
            var gift = await _giftService.GetGiftByIdAsync(id);
            if (gift == null)
                return NotFound();
            return gift;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddGift(GiftDTO giftDto)
        {
            await _giftService.AddGiftAsync(giftDto);
            return Ok();
        }

        
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateGift(int id, GiftDTO giftDto)
        {
            await _giftService.UpdateGiftAsync(id, giftDto);
            return NoContent();
        }

       
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteGift(int id)
        {
            await _giftService.DeleteGiftAsync(id);
            return NoContent();
        }
    }

}
