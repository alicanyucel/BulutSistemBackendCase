﻿using BulutSistem.Domain.Abstraction;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulutSistem.Domain.Models
{
    public class Product : BaseEntity
    {
        [MaxLength(255)]
        public string Name { get; set; } = default!;
        public string? Description { get; set; } = default!;

        [Range(0.01, 99999999.99, ErrorMessage = "Fiyat sıfırdan küçük olamaz")]
        [RegularExpression(@"^\d{1,8}(\.\d{1,2})?$", ErrorMessage = "Fiyat formatı geçersiz. Lütfen 10 haneli (2 ondalıklı) formatta girin.")]
        public decimal Price { get; set; } = default!;

        [Range(0, int.MaxValue, ErrorMessage = "Stok miktarı geçersiz.")]
        public int StockQuantity { get; set; } = default!;

        //[ForeignKey("CategoryId")]
        //public Category Category { get; set; } = default!;

        public virtual ICollection<ProductVariant> ProductVariants { get; set; } = default!;
    }

}
