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
        [Range(0.01, 99999999.99, ErrorMessage = "Fiyat 0.01 ile 99999999.99 arasında olmalıdır.")]
        [RegularExpression(@"^\d{1,8}(\.\d{1,2})?$", ErrorMessage = "Fiyat formatı geçersiz. Lütfen 10 haneli (2 ondalıklı) formatta girin.")]
        public decimal Price { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Stok miktarı geçersiz.")]
        public int Stock_Quantity {get;set;}
        [ForeignKey("Category")]
        public Category Category { get; set; }
    }
}
