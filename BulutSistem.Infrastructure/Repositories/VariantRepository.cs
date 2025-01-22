using BulutSistem.Domain.Models;
using BulutSistem.Domain.Repositories;
using BulutSistem.Infrastructure.DataContext;
using GenericRepository;


namespace BulutSistem.Infrastructure.Repositories
{
    internal sealed class VariantRepository : Repository<Variant, ApplicationDbContext>, IVariantRepository
    {
        public VariantRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
