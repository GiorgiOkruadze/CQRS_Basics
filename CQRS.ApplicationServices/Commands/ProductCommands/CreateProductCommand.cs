using CQRS.ApplicationShared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.ApplicationServices.Commands.ProductCommands
{
    public class CreateProductCommand:IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<VolumeDto> Volumes { get; set; }
        public List<ResellerDto> Resellers { get; set; }
    }
}
