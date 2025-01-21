using BulutSistem.Domain.Models;
using System.ComponentModel.DataAnnotations;


namespace BulutSistem.Appllication.Features;

public sealed class ParentIdRequiredIfSubCategoryAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var category = validationContext.ObjectInstance as Category;
        if (category != null)
        {
            if (category.IsSubCategory && !category.ParentId.HasValue)
            {
                return new ValidationResult("Alt kategori ekleniyorsa, parent_id belirtilmelidir.");
            }
        }
        return ValidationResult.Success;
    }
}