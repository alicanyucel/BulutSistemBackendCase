

using MediatR;
using TS.Result;

namespace BulutSistem.Appllication.Features.Categories.AddCategory;

public sealed record AddProductCommad(string Name,string? Description,int ParentCategoryId,bool IsDeleted) : IRequest<Result<string>>;

