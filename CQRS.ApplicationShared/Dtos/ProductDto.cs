using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.ApplicationShared.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<VolumeDto> Volumes { get; set; }
        public List<ResellerDto> Resellers { get; set; }
    }
}
