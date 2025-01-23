

using AutoMapper;
using BulutSistem.Domain.Models;
using BulutSistem.Domain.Repositories;
using MediatR;
using TS.Result;

namespace BulutSistem.Appllication.Features.Products.AddProduct
{
    internal sealed class AddProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<AddProductCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            Product product = mapper.Map<Product>(request);
            await productRepository.AddAsync(product, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Product kaydı yapıldı";
        }
    }

}
