using AutoMapper;
using ProductCart.Data.Commands;
using ProductCart.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCart.Service.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddProductRequest, AddProductCommand>().ReverseMap();
        }
    }
}
