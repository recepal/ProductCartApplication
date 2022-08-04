using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCart.Domain.Exceptions
{
    public class BaseException : Exception
    {
        public int HttpStatusCode { get; }

        public string Description { get; }

        public BaseException(string message, string description, int httpStatusCode) : base(message)
        {
            HttpStatusCode = httpStatusCode;
            Description = description;
        }
    }
}
