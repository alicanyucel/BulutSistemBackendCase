using BulutSistem.Domain.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace BulutSistem.Domain.Models
{
    public  class Variant:BaseEntity
    {
        [Required] 
        [StringLength(255)] 
        public string VariantName { get; set; }
        [Required] 
        [Column(TypeName = "decimal(10,2)")]
        [Range(0.01, 99999999.99, ErrorMessage = "Fiyat sıfırdan küçük olamaz")]
        public decimal Price { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stok miktarı geçersiz.")]
        public int StockQuantity { get; set; }
        [ForeignKey("Product")]
        public virtual  Product Product { get; set; } // n to n ilişki
    }
}
