using BulutSistem.Domain.Models;
using BulutSistem.Domain.Repositories;
using BulutSistem.Infrastructure.DataContext;
using GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulutSistem.Infrastructure.Repositories
{
    internal sealed class ProductRepository : Repository<Product, ApplicationDbContext>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
