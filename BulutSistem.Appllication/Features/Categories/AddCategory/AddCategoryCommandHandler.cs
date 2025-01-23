using AutoMapper;
using BulutSistem.Domain.Models;
using BulutSistem.Domain.Repositories;
using MediatR;
using TS.Result;

namespace BulutSistem.Appllication.Features.Categories.AddCategory
{
    internal sealed class AddCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<AddCategoryCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = mapper.Map<Category>(request);
            await categoryRepository.AddAsync(category, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Kategori kaydı yapıldı";
        }
    }
}