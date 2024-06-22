using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Base.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CDCompletedController : ControllerBase
    {
        public CDCompletedController()
        {
            
        }

        [HttpGet]

        public IActionResult Get()
        {
            return Ok("Lần này mà không được là do Khoa Hết");
        }
    }
}
