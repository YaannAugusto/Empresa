using Microsoft.AspNetCore.Mvc;

namespace Loja.Controllers
{
    [ApiController]
    [Route("")]

    public class HomeController : ControllerBase
    {
        [HttpGet("")]

        public IActionResult Get()
        {
            return Ok();
        }

    }

}
