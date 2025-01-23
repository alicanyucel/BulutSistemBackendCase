

using MediatR;
using TS.Result;

namespace BulutSistem.Appllication.Features.Products.AddProduct;

public sealed record AddProductCommand(string Name, string? Description, decimal Price, int StockQuantity, int CategoryId, bool IsDeleted, int ProductVariantsId) : IRequest<Result<string>>;

  