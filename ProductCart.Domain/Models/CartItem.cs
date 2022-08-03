using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCart.Domain.Models
{
    public class CartItem : BaseEntity
    {
        public Guid CartId { get; protected set; }
        public Guid ProductId { get; protected set; }
        public int Quantity { get; protected set; }
        public decimal ItemPrice { get; protected set; }

        #region actions
        public CartItem CreateCartItem(Guid cartId, Guid productId, int quantity, decimal price)
        {
            Id = Guid.NewGuid();
            CartId = cartId;
            ProductId = productId;
            Quantity = quantity;
            ItemPrice = quantity * price;

            return this;
        }
        #endregion
    }
}
