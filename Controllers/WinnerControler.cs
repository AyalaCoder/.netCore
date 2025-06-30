using final_project.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace final_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WinnerController : ControllerBase
    {
        private readonly IWinnerService _winnerService;

        public WinnerController(IWinnerService winnerService)
        {
            _winnerService = winnerService;
        }

        [HttpGet("report")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetReport()
        {
            var result = await _winnerService.GetWinnerReportAsync();
            return Ok(result);
        }
    }
}
