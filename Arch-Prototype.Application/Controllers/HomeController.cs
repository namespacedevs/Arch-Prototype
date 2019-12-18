using Microsoft.AspNetCore.Mvc;

namespace Arch_Prototype.Application.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var result = new
            {
                Version = "1.0.0"
            };
            return Ok(result);
        }
    }
}
