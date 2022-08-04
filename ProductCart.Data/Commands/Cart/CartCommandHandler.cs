using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductCart.Domain.Dtos;
using ProductCart.Domain.Models;
using ProductCart.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCart.Data.Commands.Cart
{
    public class CartCommandHandler : IRequestHandler<AddProductToCartCommand, bool>,
                                      IRequestHandler<CreateCartCommand, CartDto>,
                                      IRequestHandler<UpdateCartCommand, bool>
    {
        private readonly PostgreDbContext _context;
        private readonly IMapper _mapper;

        public CartCommandHandler(PostgreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AddProductToCartCommand request, CancellationToken cancellationToken)
        {
            CartItem cartItem = new CartItem().CreateCartItem(request.CartId, request.ProductId, request.Quantity, request.Price);
          
            await _context.CartItems.AddAsync(cartItem);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<CartDto> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            Domain.Models.Cart cart = new Domain.Models.Cart().CreateCart();

            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();

            var cartDto = _mapper.Map<CartDto>(cart);

            return cartDto;
        }

        public async Task<bool> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            Domain.Models.Cart cart = await _context.Carts.FirstOrDefaultAsync(f => f.Id == request.CartId);

            cart.UpdateAmount(request.Price, request.Quantity);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
