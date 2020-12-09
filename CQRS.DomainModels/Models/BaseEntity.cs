using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CQRS.DomainModels.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
