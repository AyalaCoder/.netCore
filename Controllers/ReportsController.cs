using final_project.BL;
using final_project.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace final_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "admin")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportsService _reportsService;

        public ReportsController(IReportsService reportsService)
        {
            _reportsService = reportsService;
        }

        [HttpGet("income")]
        public async Task<IActionResult> GetTotalIncome()
        {
            decimal totalIncome = await _reportsService.GetTotalIncomeAsync();
            return Ok(new { TotalIncome = totalIncome });
        }

        
    
    }
}
