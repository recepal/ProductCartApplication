using AutoMapper;
using MediatR;
using ProductCart.Data.Commands;
using ProductCart.Data.Queries;
using ProductCart.Domain.Dtos;
using ProductCart.Domain.Requests;
using ProductCart.Domain.Services;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductCart.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediatrHandler;
        private readonly IMapper _mapper;
        private readonly IDatabase _redisDatabase;

        public ProductService(IMediator mediatrHandler, IMapper mapper, IConnectionMultiplexer redis)
        {
            _mediatrHandler = mediatrHandler;
            _mapper = mapper;
            _redisDatabase = redis.GetDatabase();
        }
        public async Task<bool> AddProduct(AddProductRequest request)
        {
            AddProductCommand command = _mapper.Map<AddProductCommand>(request);
            var result = await _mediatrHandler.Send(command);
            return result;
        }

        public async Task<ProductDto> GetProductById(Guid id)
        {
            var query = new GetProductByIdQuery(id);
            var result = await _mediatrHandler.Send(query);
            return result;
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            var result = await GetProductsFromRedis();

            if (result is null)
            {
                var query = new GetProductsQuery();
                result = await _mediatrHandler.Send(query);
                await SetRedisProducts(result);
            }

            return result;
        }

        private async Task<List<ProductDto>> GetProductsFromRedis()
        {
            var data = await _redisDatabase.StringGetAsync("Products");
            return data.IsNull ? null : JsonSerializer.Deserialize<List<ProductDto>>(data);
        }

        private async Task SetRedisProducts(List<ProductDto> products)
        {
            var response = JsonSerializer.Serialize(products);
            await _redisDatabase.StringSetAsync("Products", response, TimeSpan.FromDays(1));
        }
    }
}
