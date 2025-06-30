using final_project.BL;
using final_project.models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace final_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpPost]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> Add(PurchaseDTO dto)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _purchaseService.AddPurchaseAsync(dto, userId);
            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _purchaseService.GetAllPurchasesAsync();
            return Ok(list);
        }

        [HttpGet("byGift/{giftId}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetByGift(int giftId)
        {
            var list = await _purchaseService.GetByGiftIdAsync(giftId);
            return Ok(list);
        }
    }
}
