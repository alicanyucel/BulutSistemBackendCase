
using BulutSistem.Domain.Abstraction;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulutSistem.Domain.Models;

public sealed class ProductVariant:BaseEntity
{
    [ForeignKey("Product")]
    public Product Product { get; set; }
    [Required]
    [StringLength(255, ErrorMessage = "Variant adı en fazla 255 karakter olabilir.")]
    [MaxLength(255)]
    public string VariantName { get; set; }
    [Range(0.01, 99999999.99, ErrorMessage = "Fiyat 0.01 ile 99999999.99 arasında olmalıdır.Fiyat sıfırdan küçük olamaz")]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "Stok miktarı geçersiz.")]
    public int StockQuantity { get; set; }
}
