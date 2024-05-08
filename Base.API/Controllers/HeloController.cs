using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Base.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Helo()
        {
            var helo =  "helo";
            return Ok(helo);               
        }
    }
}
