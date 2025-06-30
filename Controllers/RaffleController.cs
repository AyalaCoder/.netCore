using final_project.BL;
using final_project.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace final_project.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    public class RaffleController: ControllerBase
    {
        private readonly IRaffleService _raffleService;

        public RaffleController(IRaffleService raffleService)
        {
            _raffleService = raffleService;
        }
        [HttpPost("raffle/{giftId}")]
        public async Task<IActionResult> RaffleGift(int giftId)
        {
            var result = await _raffleService.RaffleGiftAsync(giftId);

            if (result==null)
                return BadRequest("there is no winner for this gift");

            return Ok(new
            {
                GiftId = giftId,
                WinnerUserId = result
            }) ;
        }


    }
}
