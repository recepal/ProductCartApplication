using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCart.Domain.Models
{
    public class Product : BaseEntity
    {
        public string? Code { get; protected set; }
        public string? Name { get; protected set; }
        public decimal Price { get; protected set; }
        public int Quantity { get; protected set; }

        #region actions
        public Product CreateProduct(string? code, string? name, decimal price, int quantity)
        {
            Id = Guid.NewGuid();
            Code = code;
            Name = name;
            Price = price;
            Quantity = quantity;
            IsDeleted = false;

            return this;
        }
        #endregion
    }
}
