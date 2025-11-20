using Microsoft.AspNetCore.Mvc;

namespace MinimalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok(new { message = "Hello from API" });

        [HttpGet("time")]
        public IActionResult GetTime() => Ok(new { time = DateTime.Now });
    }
}
