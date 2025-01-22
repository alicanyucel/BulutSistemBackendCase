
using BulutSistem.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace BulutSistem.Domain.Validation
{
    public class ParentIdRequiredIfSubCategoryAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var category = (Category)validationContext.ObjectInstance;

            // Eğer ParentId null ise ve kategori alt kategori değilse (yani ana kategori)
            if (!category.ParentCategoryId.HasValue && validationContext.ObjectType == typeof(Category))
            {
                return ValidationResult.Success;
            }

            // Eğer ParentId null ise ve kategori alt kategori ise hata ver
            if (category.ParentCategoryId.HasValue == false)
            {
                return new ValidationResult("Alt kategori için ParentId belirtilmelidir.");
            }

            return ValidationResult.Success;
        }
    }

}
