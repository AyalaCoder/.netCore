using final_project.BL;
using final_project.models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace final_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonorController : ControllerBase
    {
        private readonly IDonorService _donorService;

        public DonorController(IDonorService donorService)
        {
            _donorService = donorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DonorDTO>>> GetAll()
        {
            return await _donorService.GetAllDonorAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DonorDTO>> GetById(int id)
        {
            var donor = await _donorService.GetDonorByIdAsync(id);
            if (donor == null) return NotFound();
            return donor;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Add(DonorDTO dto)
        {
            await _donorService.AddDonorAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Update(int id, DonorDTO dto)
        {
            await _donorService.UpdateDonorAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _donorService.DeleteDonorAsync(id);
            return NoContent();
        }
    }
}
