using BulutSistem.Domain.Models;
using BulutSistem.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;



namespace BulutSistem.Appllication.Features.Products.GetProduct
{
    internal sealed class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAll().OrderBy(p => p.Name).ToListAsync(cancellationToken);
        }
    }
}
