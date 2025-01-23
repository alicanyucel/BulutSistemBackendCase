using MediatR;
using TS.Result;

namespace BulutSistem.Appllication.Features.Products.UpdateProduct
{
    public sealed record UpdateProductCommand(int Id,string Name, string? Description, decimal Price, int StockQuantity, int CategoryId, bool IsDeleted, int ProductVariantsId) : IRequest<Result<string>>;
}
