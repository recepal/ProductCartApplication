using AutoMapper;
using MediatR;
using ProductCart.Domain.Dtos;
using ProductCart.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCart.Data.Commands.Cart
{
    public class CartCommandHandler : IRequestHandler<AddProductToCartCommand, bool>,
                                      IRequestHandler<CreateCartCommand,CartDto>
    {
        private readonly PostgreDbContext _context;
        private readonly IMapper _mapper;

        public CartCommandHandler(PostgreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<bool> Handle(AddProductToCartCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<CartDto> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            Domain.Models.Cart cart = new Domain.Models.Cart().CreateCart();

            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();

            var cartDto = _mapper.Map<CartDto>(cart);

            return cartDto;
        }
    }
}
