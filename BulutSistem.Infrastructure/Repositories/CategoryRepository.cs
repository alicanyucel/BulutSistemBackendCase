using BulutSistem.Domain.Models;
using BulutSistem.Domain.Repositories;
using BulutSistem.Infrastructure.DataContext;
using GenericRepository;

namespace BulutSistem.Infrastructure.Repositories
{
    internal sealed class CategoryRepository : Repository<Category, ApplicationDbContext>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task GetByIdAsync(int value, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
