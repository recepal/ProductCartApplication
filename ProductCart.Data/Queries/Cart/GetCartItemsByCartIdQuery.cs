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
    public class GetCartItemsByCartIdQuery : IRequest<List<CartItemDto>>
    {
        public Guid CartId { get; set; }

        public GetCartItemsByCartIdQuery(Guid cartId)
        {
            CartId = cartId;
        }
    }
}
