using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCart.Domain.Models
{
    public class BaseEntity
    {
        public Guid Id { get; protected set; }
        public bool IsDeleted { get; protected set; }
    }
}
