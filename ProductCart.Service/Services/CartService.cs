using MediatR;
using ProductCart.Data.Commands;
using ProductCart.Data.Queries;
using ProductCart.Domain.Models;
using ProductCart.Domain.Requests;
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
        private readonly IMediator _mediatrHandler;

        public CartService(IMediator mediatrHandler)
        {
            _mediatrHandler = mediatrHandler;
        }

        public async Task<bool> AddProductToCart(AddProductToCartRequest request)
        {
            var product = await _mediatrHandler.Send(new GetProductByIdQuery(request.ProductId));

            var stockResponse = StockControl(request.Quantity, product.Quantity);
            if(!stockResponse) throw new Exception();
            var cart =await GetActiveCart();
            //await _mediatrHandler
            return true;
        }

        private bool StockControl(int requestQuantity, int productQuantity)
        {
            if (productQuantity < requestQuantity) return false;
            return true;
        }

        private async Task<Cart> GetActiveCart()
        {
            var cart = await _mediatrHandler.Send(new GetActiveCartQuery());
            if(cart is null)
            {
                cart = await _mediatrHandler.Send(new CreateCartCommand());
            }
            return cart;
        }
    }
}
