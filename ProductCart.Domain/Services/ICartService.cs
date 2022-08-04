using ProductCart.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCart.Domain.Services
{
    public interface ICartService
    {
        Task<bool> AddProductToCart(AddProductToCartRequest request);
    }
}
