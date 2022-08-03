using ProductCart.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCart.Service.Services
{
    public class CartService : ICartService
    {
        //private readonly IMediator _mediatrHandler;

        //public CartService(IMediator mediatrHandler)
        //{
        //    _mediatrHandler = mediatrHandler;
        //}

        //public async Task<bool> AddProductToCart(AddProductToCartRequest request)
        //{
        //    var product = await _mediatrHandler.Send(new GetProductByIdQuery(request.ProductId));

        //    if (product is null) throw new Exception();
        //    if (product.Quantity < request.Quantity) throw new Exception();


        //    //await _mediatrHandler
        //    return true;
        //}
    }
}
