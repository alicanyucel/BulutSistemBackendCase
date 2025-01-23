using MediatR;
using TS.Result;

namespace BulutSistem.Appllication.Features.Variants.DeleteVaritants
{
    public sealed record DeleteVariantByIdCommand(int Id) : IRequest<Result<string>>;
}
