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

namespace ProductCart.Data.Queries
{
    public class CartQueryHandler : IRequestHandler<GetActiveCartQuery, CartDto>,
                                    IRequestHandler<GetCartItemsByCartIdQuery, List<CartItemDto>>
    {
        private readonly PostgreDbContext _context;
        private readonly IMapper _mapper;

        public CartQueryHandler(PostgreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CartDto> Handle(GetActiveCartQuery request, CancellationToken cancellationToken)
        {
            var activeCart = await _context.Carts.FirstOrDefaultAsync(f => f.IsActive);
            var cartDto = _mapper.Map<CartDto>(activeCart);
            return cartDto;
        }

        public async Task<List<CartItemDto>> Handle(GetCartItemsByCartIdQuery request, CancellationToken cancellationToken)
        {
            var cartItems = await _context.CartItems.Where(f => f.CartId == request.CartId).ToListAsync();

            var cartItemDtos = _mapper.Map<List<CartItemDto>>(cartItems);

            return cartItemDtos;

        }
    }
}
