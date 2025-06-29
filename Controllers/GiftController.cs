using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftController : ControllerBase
    {
        [HttpGet]
        [HttpPost]
        [HttpPut("{id}")]
        [HttpDelete("{id}")]
    }
}
