﻿using ProductCart.Domain.Requests;
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
    }
}
