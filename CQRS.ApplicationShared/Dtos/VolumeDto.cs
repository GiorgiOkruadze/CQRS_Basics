using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CQRS.ApplicationShared.Dtos
{
    public class VolumeDto
    {
        public int Id { get; set; }
        public string SizeName { get; set; }
        public double Price { get; set; }
        public ProductDto Product { get; set; }
    }
}
