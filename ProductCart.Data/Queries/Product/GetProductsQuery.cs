using MediatR;
using ProductCart.Domain.Dtos;
using ProductCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCart.Data.Queries
{
    public class GetProductsQuery : IRequest<List<ProductDto>>
    {
        
    }
}
