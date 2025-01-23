

using AutoMapper;
using BulutSistem.Domain.Models;
using BulutSistem.Domain.Repositories;
using MediatR;
using TS.Result;

namespace BulutSistem.Appllication.Features.Variants.AddVariants
{
    internal sealed class AddVariantCommandHandler(IVariantRepository variantRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<AddVariantCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(AddVariantCommand request, CancellationToken cancellationToken)
        {
            Variant variant = mapper.Map<Variant>(request);
            await variantRepository.AddAsync(variant, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Variant kaydı yapıldı";
        }
    }
}
