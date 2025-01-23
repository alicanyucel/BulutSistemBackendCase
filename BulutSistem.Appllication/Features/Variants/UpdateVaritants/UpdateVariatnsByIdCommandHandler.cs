using AutoMapper;
using BulutSistem.Domain.Models;
using BulutSistem.Domain.Repositories;
using MediatR;
using TS.Result;

namespace BulutSistem.Appllication.Features.Variants.UpdateVaritants
{
    internal sealed class UpdateVariantByIdCommandHandler(IVariantRepository variantRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateVariantByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateVariantByIdCommand request, CancellationToken cancellationToken)
        {
            Variant variant = await variantRepository.GetByExpressionWithTrackingAsync(P => P.Id == request.Id, cancellationToken);
            if (variant == null)
            {
                return Result<string>.Failure("variant yok");
            }
            mapper.Map(request, variant);
            variantRepository.Update(variant);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "variant güncelledi";

        }
    }
}
