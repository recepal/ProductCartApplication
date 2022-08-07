using ProductCart.Domain.Dtos;
using ProductCart.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCart.Domain.Services
{
    public interface IProductService
    {
        Task<bool> AddProduct(AddProductRequest request);
        Task<ProductDto> GetProductById(Guid id);
        Task<List<ProductDto>> GetProducts();
    }
}
