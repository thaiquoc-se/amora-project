using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Base.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public ActionResult Index()
        {
            return Ok("CI/CD successfully Please Oh no Oh no!!!");
        }
    }
}
