using AutoMapper;
using CQRS.ApplicationServices.Querys.ProductQuerys;
using CQRS.ApplicationShared.Dtos;
using CQRS.CoreServices.Repositorys;
using CQRS.DomainModels.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.ApplicationServices.Handlers.ProductHandlers
{
    public class ReadAllProductsHandler : IRequestHandler<ReadAllProductQuerys, IEnumerable<ProductDto>>
    {
        private readonly IRepository<Product> _productRepository = default;
        private readonly IMapper _mapper;

        public ReadAllProductsHandler(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository; 
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> Handle(ReadAllProductQuerys request, CancellationToken cancellationToken)
        {
            var allProducts = await _productRepository
                .Get()
                .Include(o => o.ProductResellers)
                .Include(o => o.Volumes)
                .ToListAsync();

            return _mapper.Map<List<ProductDto>>(allProducts);
        }
    }
}
