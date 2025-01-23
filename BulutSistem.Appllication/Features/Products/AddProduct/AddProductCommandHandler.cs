

using AutoMapper;
using BulutSistem.Appllication.Features.Categories.AddCategory;
using BulutSistem.Domain.Models;
using BulutSistem.Domain.Repositories;
using MediatR;
using TS.Result;

namespace BulutSistem.Appllication.Features.Products.AddProduct
{
    internal sealed class AddProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<AddProductCommad, Result<string>>
    {
        public async Task<Result<string>> Handle(AddProductCommad request, CancellationToken cancellationToken)
        {
            Product product = mapper.Map<Product>(request);
            await productRepository.AddAsync(product, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Product kaydı yapıldı";
        }
    }

}
