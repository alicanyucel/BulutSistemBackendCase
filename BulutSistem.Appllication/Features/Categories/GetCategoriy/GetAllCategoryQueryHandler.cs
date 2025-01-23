using BulutSistem.Domain.Models;
using BulutSistem.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BulutSistem.Appllication.Features.Categories.GetCategoriy
{
    internal sealed class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetAll().OrderBy(p => p.Name).ToListAsync(cancellationToken);
        }
    }
}
