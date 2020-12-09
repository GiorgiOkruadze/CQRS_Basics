using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.DomainModels.Models
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public List<Volume> Volumes { get; set; } = new List<Volume>();
        public List<ProductReseller> ProductResellers { get; set; } = new List<ProductReseller>();
    }
}
