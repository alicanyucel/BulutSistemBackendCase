﻿
using BulutSistem.Domain.Abstraction;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulutSistem.Domain.Models;

public  class ProductVariant:BaseEntity
{
    // tamam burdan devam edilecek dll gormuyordu
    [ForeignKey("ProductId")]
    public Product Product { get; set; } = default!;
    [Required]
    [StringLength(255, ErrorMessage = "Variant adı en fazla 255 karakter olabilir.")]
    [MaxLength(255)]
    [UniqueVariantName] // variant adı benzersiz olmalı ürün bazında
    public string VariantName { get; set; } = default!;
    [Range(0.01, 99999999.99, ErrorMessage = "Fiyat sıfırdan küçük olamaz")]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }= default!;
    [Range(0, int.MaxValue, ErrorMessage = "Stok miktarı geçersiz.")]
    public int StockQuantity { get; set; } = default!;
}
