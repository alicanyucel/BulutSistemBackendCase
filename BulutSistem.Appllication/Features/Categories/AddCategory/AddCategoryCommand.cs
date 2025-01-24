
using MediatR;
using TS.Result;

namespace BulutSistem.Appllication.Features.Categories.AddCategory;

public sealed record AddCategoryCommand(
        string Name,
        string? Description,
        int? CategoryId,
        bool IsDeleted
    ) :  IRequest<Result<string>>;

