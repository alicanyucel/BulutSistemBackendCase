using BulutSistem.Domain.Abstraction;
using BulutSistem.Domain.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BulutSistem.Domain.Models
{

    public class Category : BaseEntity
    {
        [MaxLength(255)]
        public string Name { get; set; } = default!;

        public string? Description { get; set; }

        public bool IsDeleted { get; set; }
        [ForeignKey("ParentCategoryId")]
        public int? ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }

        public virtual ICollection<Category> SubCategories { get; set; } = new List<Category>();

        public bool IsSubCategory => ParentCategoryId.HasValue;

    }

}