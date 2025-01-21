using BulutSistem.Domain.Abstraction;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulutSistem.Domain.Models
{
    public sealed class Product : BaseEntity
    {
        [MaxLength(255)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock_Quantity {get;set;}
        [ForeignKey("Category")]
        public Category Category { get; set; }
    }
}
