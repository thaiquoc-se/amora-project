using Base.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Base.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        //[HttpGet]
        //public Task<IActionResult> GetAllProduct(int pageSize = 10, int pageIndex = 0)
        //{

        //}
    }
}
