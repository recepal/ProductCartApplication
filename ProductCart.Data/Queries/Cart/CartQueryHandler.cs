using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductCart.Domain.Models;
using ProductCart.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCart.Data.Queries
{
    public class CartQueryHandler : IRequestHandler<GetActiveCartQuery, Cart>
    {
        private readonly PostgreDbContext _context;

        public CartQueryHandler(PostgreDbContext context)
        {
            _context = context;
        }

        public async Task<Cart> Handle(GetActiveCartQuery request, CancellationToken cancellationToken)
        {

            var activeCart = await _context.Carts.FirstOrDefaultAsync(f => f.IsActive);
            return activeCart;
        }

    }
}
