using Microsoft.AspNetCore.Mvc;
using ProductCart.Domain.Requests;
using ProductCart.Domain.Services;

namespace ProductCart.API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(AddProductRequest request)
        {
            return Ok(await _productService.AddProduct(request));
        }

        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            return Ok(await _productService.GetProductById(id));
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _productService.GetProducts());
        }
    }
}
