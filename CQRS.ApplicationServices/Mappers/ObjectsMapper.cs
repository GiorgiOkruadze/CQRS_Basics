using AutoMapper;
using CQRS.ApplicationServices.Commands.ProductCommands;
using CQRS.ApplicationShared.Dtos;
using CQRS.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQRS.ApplicationServices.Mappers
{
    public class ObjectsMapper:Profile
    {
        public ObjectsMapper()
        {
            CreateMap<Volume, VolumeDto>().ReverseMap();

            CreateMap<Product, ProductDto>()
                .ForMember(m => m.Volumes, d => d.MapFrom(o => o.Volumes))
                .ForMember(m => m.Resellers, d => d.MapFrom(o => o.ProductResellers.Select(r => r.Reseller)))
                .ReverseMap();

            CreateMap<Reseller, ResellerDto>()
                .ForMember(m => m.Products, d => d.MapFrom(o => o.ProductResellers.Select(p => p.Product)))
                .ReverseMap();

            CreateMap<CreateProductCommand, ProductDto>().ReverseMap();
        }
    }
}
