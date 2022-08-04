using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCart.Data.Commands.Cart
{
    public class UpdateCartCommand : IRequest<bool>
    {
        public Guid CartId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public UpdateCartCommand(Guid cartId, int quantity, decimal price)
        {
            CartId = cartId;
            Quantity = quantity;
            Price = price;
        }
    }
}
