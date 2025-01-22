using BulutSistem.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
public class UniqueVariantNameAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var dbContext = (DbContext)validationContext.GetService(typeof(DbContext)); 
        var productVariantRepository = new ProductVariantRepository(dbContext); 

        string variantName = value?.ToString();
        if (!string.IsNullOrEmpty(variantName))
        {
            var existingVariant = productVariantRepository.GetVariantByNameAsync(variantName).Result;
            if (existingVariant != null)
            {
                return new ValidationResult("Varyant adı benzersiz olmalıdır.");
            }
        }

        return ValidationResult.Success;
    }
}
