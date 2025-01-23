using BulutSistem.Domain.Models;
using MediatR;


namespace BulutSistem.Appllication.Features.Variants.GetAllVariants
{
    public sealed record GetAllVariantQuery() : IRequest<List<Variant>>;
}
