using Microsoft.AspNetCore.Mvc;
using ProductCart.Domain.Requests;
using ProductCart.Domain.Services;

namespace ProductCart.API.Controllers
{
    public class CartController : BaseController
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("Test")]
        public async Task<IActionResult> ServiceTest()
        {
            return Ok(true);
        }

        [HttpPost("AddProductToCart")]
        public async Task<IActionResult> AddProductToCart(AddProductToCartRequest request)
        {
            return Ok(await _cartService.AddProductToCart(request));
        }
    }
}
