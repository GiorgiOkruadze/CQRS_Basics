using AutoMapper;
using CQRS.ApplicationServices.Handlers.ProductHandlers;
using CQRS.ApplicationShared.Dtos;
using CQRS.CoreServices.Repositorys;
using CQRS.DomainModels.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.ApplicationServices.Querys.ProductQuerys
{
    public class ReadProductByIdQueryHandler : IRequestHandler<ReadProductByIdQuery, ProductDto>
    {
        private readonly IRepository<Product> _productRepository = default;
        private readonly IMapper _mapper;

        public ReadProductByIdQueryHandler(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(ReadProductByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await _productRepository.GetByIdAsync(request.Id);
            return _mapper.Map<ProductDto>(item);
        }
    }
}
