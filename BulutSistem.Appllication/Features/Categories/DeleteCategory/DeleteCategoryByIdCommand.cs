using MediatR;
using TS.Result;

namespace BulutSistem.Appllication.Features.Categories.DeleteCategory
{
    public sealed record DeleteCategoryByIdCommand(int Id) : IRequest<Result<string>>;
}
