using AutoMapper;
using Base.API.RabbitMQ;
using Base.Repositories.Models;
using Base.Services.IService;
using Base.Services.ViewModel.RequestVM;
using Base.Services.ViewModel.ResponseVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Base.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IRabbitMQService _rabbitMQService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper, IRabbitMQService rabbitMQService)
        {
            _productService = productService;
            _mapper = mapper;
            _rabbitMQService = rabbitMQService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct(int pageSize = 10, int pageIndex = 0)
        {
            try
            {
                var products = await _productService.Get(pageSize, pageIndex);
                if (products == null)
                {
                    return NotFound();
                }
                var response = _mapper.Map<IEnumerable<ProductResponse>>(products);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductVM entity)
        {
            try
            {
                var newProduct = _mapper.Map<Product>(entity);
                var result = await _productService.Create(newProduct);
                if (result.IsSuccess)
                {

                    _rabbitMQService.SendingMessage<ProductVM>(entity, "amora_logs","product_queue","new_product");
                    return Ok(_mapper.Map<ProductResponse>(result.Result));
                }
                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
