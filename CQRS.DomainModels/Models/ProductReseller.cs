using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CQRS.DomainModels.Models
{
    public class ProductReseller
    {
        public int ProductId { get; set; }
        public int ResellerId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [ForeignKey("ResellerId")]
        public Reseller Reseller { get; set; }
    }
}
