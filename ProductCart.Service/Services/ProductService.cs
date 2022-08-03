﻿using AutoMapper;
using MediatR;
using ProductCart.Data.Commands;
using ProductCart.Domain.Requests;
using ProductCart.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCart.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediatrHandler;
        private readonly IMapper _mapper;

        public ProductService(IMediator mediatrHandler, IMapper mapper)
        {
            _mediatrHandler = mediatrHandler;
            _mapper = mapper;
        }
        public async Task<bool> AddProduct(AddProductRequest request)
        {
            AddProductCommand command = _mapper.Map<AddProductCommand>(request);
            var result = await _mediatrHandler.Send(command);
            return result;
        }
    }
}