using CQRS.ApplicationShared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.ApplicationServices.Querys.ProductQuerys
{
    public class ReadAllProductQuerys : IRequest<IEnumerable<ProductDto>> { }
}
