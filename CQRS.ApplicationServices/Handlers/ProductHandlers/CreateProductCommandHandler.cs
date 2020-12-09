using AutoMapper;
using CQRS.ApplicationServices.Commands.ProductCommands;
using CQRS.ApplicationShared.Dtos;
using CQRS.CoreServices.Repositorys;
using CQRS.DomainModels.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.ApplicationServices.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IRepository<Product> _productRepository = default;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productDto = _mapper.Map<ProductDto>(request);
            return await _productRepository.CreateAsync(_mapper.Map<Product>(productDto));
        }
    }
}
