using BulutSistem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulutSistem.Appllication.Features
{
    public class ParentIdRequiredIfSubCategoryAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Kategori modeline erişim sağlamak
            var category = validationContext.ObjectInstance as Category;

            // category nesnesinin null olup olmadığını kontrol edelim
            if (category != null)
            {
                // Eğer kategori bir alt kategori ise ve ParentId değeri null ise hata döndürelim
                if (category.IsSubCategory && !category.ParentId.HasValue)
                {
                    return new ValidationResult("Alt kategori ekleniyorsa, parent_id belirtilmelidir.");
                }
            }

            // Eğer doğrulama başarılıysa, ValidationResult.Success döndürelim
            return ValidationResult.Success;
        }
    }
}