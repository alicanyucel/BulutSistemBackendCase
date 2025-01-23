
using BulutSistem.Domain.Models;
using BulutSistem.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BulutSistem.Appllication.Features.Variants.GetAllVariants
{
    internal sealed class GetAllVariantQueryHandler : IRequestHandler<GetAllVariantQuery, List<Variant>>
    {
        private readonly IVariantRepository _variantRepository;

        public GetAllVariantQueryHandler(IVariantRepository variantRepository)
        {
            _variantRepository = variantRepository;
        }

      

        public async Task<List<Variant>> Handle(GetAllVariantQuery request, CancellationToken cancellationToken)
        {
            return await _variantRepository.GetAll().OrderBy(p => p.Name).ToListAsync(cancellationToken);
        }
    }
}
