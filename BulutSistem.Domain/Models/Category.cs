using BulutSistem.Appllication.Features;
using BulutSistem.Domain.Abstraction;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BulutSistem.Domain.Models
{
    public sealed class Category:BaseEntity
    {
        [MaxLength(255)]
        public string Name {  get; set; }
        public string? Description { get; set; }
        public bool IsSubCategory { get; set; }
        [ForeignKey("ParentId")]
        [ParentIdRequiredIfSubCategory] // Ekstra validation yazdık.alt kategori ekleneceke parent id belirt
        public int? ParentId { get; set; }
        public Category ParentCategory { get; set; }

    }
}
