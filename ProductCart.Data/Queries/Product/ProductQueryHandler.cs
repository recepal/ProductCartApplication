using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductCart.Domain.Dtos;
using ProductCart.Domain.Exceptions;
using ProductCart.Domain.Models;
using ProductCart.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCart.Data.Queries
{
    public class ProductQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>,
                                       IRequestHandler<GetProductsQuery, List<ProductDto>>
    {
        private readonly PostgreDbContext _context;
        private readonly IMapper _mapper;

        public ProductQueryHandler(PostgreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(f => f.Id == request.ProductId);

            if (product is null) throw new ProductNotFoundException("Bu ürün bulunamadı",
                   $"ÜrünId:{request.ProductId}");

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.ToListAsync();
            var productDtos = _mapper.Map<List<ProductDto>>(products);
            return productDtos;
        }
    }
}
