

using MediatR;
using TS.Result;

namespace BulutSistem.Appllication.Features.Categories.AddCategory;

public sealed record AddCategoryCommad(string Name,string? Description,decimal Price,int StockQuantity,int CategoryId,bool IsDeleted,int ProductVariantsId) : IRequest<Result<string>>;

