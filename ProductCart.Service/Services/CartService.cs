using AutoMapper;
using MediatR;
using ProductCart.Data.Commands;
using ProductCart.Data.Commands.Cart;
using ProductCart.Data.Queries;
using ProductCart.Domain.Dtos;
using ProductCart.Domain.Exceptions;
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
        private readonly IMapper _mapper;

        public CartService(IMediator mediatrHandler, IMapper mapper)
        {
            _mediatrHandler = mediatrHandler;
            _mapper = mapper;
        }

        public async Task<bool> AddProductToCart(AddProductToCartRequest request)
        {
            var product = await _mediatrHandler.Send(new GetProductByIdQuery(request.ProductId));

            var stockResponse = StockControl(request.Quantity, product.Quantity);
            if (!stockResponse) throw new ProductIsOutOfStockException("Ürün stoğu aşıldı.",
                $"Ürünün stoğu {product.Quantity} adet kalmıştır.");

            var cart = await GetActiveCart();

            AddProductToCartCommand addProductCommand = new AddProductToCartCommand(cart.Id, product.Id, request.Quantity, product.Price);
            await _mediatrHandler.Send(addProductCommand);

            UpdateCartCommand updateCartCommand = new UpdateCartCommand(cart.Id, request.Quantity, product.Price);
            await _mediatrHandler.Send(updateCartCommand);

            return true;
        }

        public async Task<CartWithItemsDto> GetCartWithItems()
        {
            var cart = await GetActiveCart();
            var items = await _mediatrHandler.Send(new GetCartItemsByCartIdQuery(cart.Id));

            CartWithItemsDto cartWithItemsDto = _mapper.Map<CartWithItemsDto>(cart);
            cartWithItemsDto.CartItems = items;

            return cartWithItemsDto;

        }

        private bool StockControl(int requestQuantity, int productQuantity)
        {
            if (productQuantity < requestQuantity) return false;
            return true;
        }

        private async Task<CartDto> GetActiveCart()
        {
            var cart = await _mediatrHandler.Send(new GetActiveCartQuery());
            if (cart is null)
            {
                cart = await _mediatrHandler.Send(new CreateCartCommand());
            }
            return cart;
        }
    }
}
