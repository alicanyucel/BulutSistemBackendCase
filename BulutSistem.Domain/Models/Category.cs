using BulutSistem.Domain.Abstraction;
using BulutSistem.Domain.Validation;
using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BulutSistem.Domain.Models
{

    public class Category : BaseEntity
    {
        [MaxLength(255)]
        public string Name { get; set; } = default!;

        public string? Description { get; set; } = default!;

        [ParentIdRequiredIfSubCategory(ErrorMessage = "Alt kategori için ParentId belirtilmelidir.")]
        public int? ParentCategoryId { get; set; }


        [ForeignKey("ParentCategoryId")]
        public Category? ParentCategory { get; set; }

        public bool IsDeleted { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; } = new List<Category>();
        public bool IsSubCategory => ParentCategoryId.HasValue;


    }

}