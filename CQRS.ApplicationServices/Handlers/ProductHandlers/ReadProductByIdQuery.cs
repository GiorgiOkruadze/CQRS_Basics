using CQRS.ApplicationShared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.ApplicationServices.Handlers.ProductHandlers
{
    public class ReadProductByIdQuery:IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
}
