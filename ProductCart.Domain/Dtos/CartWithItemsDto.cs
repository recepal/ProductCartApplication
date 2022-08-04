using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCart.Domain.Dtos
{
    public class CartWithItemsDto
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public decimal TotalAmount { get; set; }

        public List<CartItemDto> CartItems { get; set; }
    }
}
