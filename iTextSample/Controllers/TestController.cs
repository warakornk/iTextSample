using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iTextSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public Task<IActionResult> Get()
        {
            return Task.FromResult<IActionResult>(Ok($"Hello itext sample at {DateTime.Now}"));
        }
    }
}