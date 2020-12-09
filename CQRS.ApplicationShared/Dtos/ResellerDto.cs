using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQRS.ApplicationShared.Dtos
{
    public class ResellerDto
    {
        public int Id { get; set; }
        public string SellerName { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}