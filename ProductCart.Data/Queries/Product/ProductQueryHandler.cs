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
    public class ProductQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly PostgreDbContext _context;

        public ProductQueryHandler(PostgreDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(f => f.Id == request.ProductId);

            return product;
        }
    }
}
