
using BulutSistem.Domain.Models;
using BulutSistem.Domain.Repositories;
using MediatR;
using TS.Result;

namespace BulutSistem.Appllication.Features.Variants.DeleteVaritants
{
    internal sealed class DeleteVariantByIdCommandHandler(
      IVariantRepository variantRepository,
      IUnitOfWork unitOfWork) : IRequestHandler<DeleteVariantByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteVariantByIdCommand request, CancellationToken cancellationToken)
        {
            Variant variant = await variantRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
            if (variant is null)
            {
                return Result<string>.Failure("Variant yok");
            }

            variant.IsDeleted = true; //SOFT SİLME
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Variant soft silindi";
        }
    }
}
