using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCart.Data.Commands.Cart
{
    public class AddProductToCartCommand : IRequest<bool>
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public AddProductToCartCommand(Guid cartId, Guid productId, int quantity, decimal price)
        {
            CartId = cartId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }
    }
}
