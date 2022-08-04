using MediatR;
using ProductCart.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCart.Data.Commands
{
    public class CreateCartCommand : IRequest<CartDto>
    {
        
    }
}
