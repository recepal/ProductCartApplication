using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCart.Domain.Exceptions
{
    public class ProductNotFoundException : BaseException
    {
        public ProductNotFoundException(string message, string description) : base(message, description, (int)System.Net.HttpStatusCode.NotFound)
        {
        }
    }
}
