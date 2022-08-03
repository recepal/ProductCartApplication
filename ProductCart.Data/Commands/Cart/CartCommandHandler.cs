using MediatR;
using ProductCart.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCart.Data.Commands.Cart
{
    public class CartCommandHandler : IRequestHandler<AddProductToCartCommand, bool>
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
    }
}
