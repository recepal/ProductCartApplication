using MediatR;
using ProductCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCart.Data.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public Guid ProductId { get; set; }

        public GetProductByIdQuery(Guid productId)
        {
            ProductId = productId;
        }
    }
}
