using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCart.Domain.Dtos
{
    public class CartItemDto
    {
        public Guid Id { get; set; }
        public Guid CartId { get; protected set; }
        public Guid ProductId { get; protected set; }
        public int Quantity { get; protected set; }
        public decimal ItemPrice { get; protected set; }
    }
}
