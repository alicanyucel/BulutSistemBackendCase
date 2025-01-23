using BulutSistem.Appllication.Features.Categories.DeleteCategory;
using BulutSistem.Domain.Models;
using BulutSistem.Domain.Repositories;
using MediatR;
using TS.Result;

namespace BulutSistem.Appllication.Features.Products.DeleteProduct
{
    internal sealed class DeleteProductByIdCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            Product product = await productRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
            if (product is null)
            {
                return Result<string>.Failure("Product not found");
            }

            product.IsDeleted = true; //SOFT SİLME
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Product soft silindi";
        }
    }
}
