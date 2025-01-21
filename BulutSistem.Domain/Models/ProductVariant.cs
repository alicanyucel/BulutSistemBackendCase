
using BulutSistem.Domain.Abstraction;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulutSistem.Domain.Models;

public sealed class ProductVariant:BaseEntity
{
    [ForeignKey("Product")]
    public Product Product { get; set; }
    [MaxLength(255)]
    public string VariantName { get; set; }
    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}
