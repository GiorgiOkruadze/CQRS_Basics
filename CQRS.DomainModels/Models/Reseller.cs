using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQRS.DomainModels.Models
{
    public class Reseller:BaseEntity
    {
        public string SellerName { get; set; }
        public List<ProductReseller> ProductResellers { get; set; }
    }
}