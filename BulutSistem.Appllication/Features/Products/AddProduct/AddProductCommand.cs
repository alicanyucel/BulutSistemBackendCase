

using MediatR;
using TS.Result;

namespace BulutSistem.Appllication.Features.Products.AddProduct;

public sealed record AddProductCommand(
    int? CategoryId,
    string Name,
    string? Description,
    decimal Price,
    int StockQuantity,
    bool IsDeleted
) : IRequest<Result<string>>;
