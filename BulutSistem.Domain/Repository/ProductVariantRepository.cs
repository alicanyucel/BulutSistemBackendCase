using BulutSistem.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace BulutSistem.Infrastructure.Repositories
{
    public class ProductVariantRepository
    {
        private readonly DbContext _context;

        public ProductVariantRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<ProductVariant> GetVariantByNameAsync(string variantName)
        {
            return await _context.Set<ProductVariant>().FirstOrDefaultAsync(v => v.VariantName == variantName);
        }
    }

}
