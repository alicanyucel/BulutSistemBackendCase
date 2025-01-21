using BulutSistem.Domain.Models;
using BulutSistem.Domain.Repositories;
using BulutSistem.Infrastructure.DataContext;
using GenericRepository;

namespace BulutSistem.Infrastructure.Repositories
{
    internal sealed class UserRoleRepository : Repository<UserRole, ApplicationDbContext>, IUserRoleRepository
    {
        public UserRoleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
