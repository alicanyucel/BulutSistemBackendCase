

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
        [ForeignKey("ParentId")]
        public int? ParentId { get; set; }
        public Category ParentCategory { get; set; }

    }
}
