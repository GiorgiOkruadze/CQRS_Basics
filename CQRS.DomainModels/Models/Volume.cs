using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CQRS.DomainModels.Models
{
    public class Volume:BaseEntity
    {
        public string SizeName { get; set; }
        public double Price { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
