using MediatR;
using ProductCart.Infrastructure.Database;
using ProductCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCart.Data.Commands
{
    public class ProductCommandHandler : IRequestHandler<AddProductCommand, bool>
    {
        private readonly PostgreDbContext _context;
        public ProductCommandHandler(PostgreDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new Product().CreateProduct(request.Code, request.Name, request.Price, request.Quantity);

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
