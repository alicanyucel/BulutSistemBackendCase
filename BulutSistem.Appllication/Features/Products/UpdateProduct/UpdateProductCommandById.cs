using AutoMapper;
using BulutSistem.Domain.Models;
using BulutSistem.Domain.Repositories;
using MediatR;
using TS.Result;

namespace BulutSistem.Appllication.Features.Products.UpdateProduct
{
    internal sealed class UpdateProductyByIdCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateProductByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateProductByIdCommand request, CancellationToken cancellationToken)
        {
            Product product= await productRepository.GetByExpressionWithTrackingAsync(P => P.Id == request.Id, cancellationToken);
            if (product == null)
            {
                return Result<string>.Failure("product yok");
            }
            mapper.Map(request, product);
            productRepository.Update(product);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "product güncelledi";

        }
    }
}
