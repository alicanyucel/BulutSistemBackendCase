using MediatR;
using TS.Result;

namespace BulutSistem.Appllication.Features.Variants.UpdateVaritants
{
    public sealed record UpdateVariantByIdCommand(int Id,string Name, decimal Price, int ProductId, int StockQuantity) : IRequest<Result<string>>;
}
