

using BulutSistem.Domain.Models;
using MediatR;

namespace BulutSistem.Appllication.Features.Categories.GetCategoriy
{
    public sealed record GetAllCategoryQuery() : IRequest<List<Category>>;
}
