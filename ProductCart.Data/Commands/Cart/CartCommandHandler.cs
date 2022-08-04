using MediatR;
using ProductCart.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCart.Data.Commands.Cart
{
    public class CartCommandHandler : IRequestHandler<AddProductToCartCommand, bool>,
                                      IRequestHandler<CreateCartCommand,Domain.Models.Cart>
    {
        private readonly PostgreDbContext _context;
        public CartCommandHandler(PostgreDbContext context)
        {
            _context = context;
        }

        public Task<bool> Handle(AddProductToCartCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Models.Cart> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            Domain.Models.Cart cart = new Domain.Models.Cart().CreateCart();

            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();

            return cart;
        }
    }
}
