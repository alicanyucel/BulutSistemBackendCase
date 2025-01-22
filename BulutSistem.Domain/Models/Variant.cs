using BulutSistem.Domain.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace BulutSistem.Domain.Models
{
    public  class Variant:BaseEntity
    {
        [Required]
        [StringLength(255)]
        [UniqueVariantName(ErrorMessage = "Varyant adı benzersiz olmalıdır.")]
        public string VariantName { get; set; } = default!;
        [Required] 
        [Column(TypeName = "decimal(10,2)")]
        [Range(0.01, 99999999.99, ErrorMessage = "Fiyat sıfırdan küçük olamaz")]
        public decimal Price { get; set; }= default!;
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stok miktarı geçersiz.")]
        public int StockQuantity { get; set; }=default!;
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; } = default!; // n to n ilişki
    }
}
