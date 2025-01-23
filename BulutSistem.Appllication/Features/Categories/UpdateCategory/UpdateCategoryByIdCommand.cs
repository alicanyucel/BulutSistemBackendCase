

using MediatR;
using TS.Result;

namespace BulutSistem.Appllication.Features.Categories.UpdateCategory;


public  record UpdateCategoryByIdCommand(int Id,string Name, string? Description, int ParentCategoryId, bool IsDeleted) : IRequest<Result<string>>;