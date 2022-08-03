using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCart.Domain.Models
{
    public class Cart : BaseEntity
    {
        public string? Description { get; protected set; }
        public decimal TotalAmount { get; protected set; }
        public bool IsActive { get; protected set; }

        #region actions
        public Cart CreateCart()
        {
            Id = Guid.NewGuid();
            IsActive = true;
            return this;
        }

        #endregion
    }
}
