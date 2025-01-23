using BulutSistem.Domain.Models;
using BulutSistem.Domain.Repositories;
using MediatR;
using TS.Result;

namespace BulutSistem.Appllication.Features.Categories.DeleteCategory
{
    internal sealed class DeleteBlogByIdCommandHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteCategoryByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            Category category = await categoryRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
            if (category is null)
            {
                return Result<string>.Failure("Category not found");
            }

            category.IsDeleted = true; //SOFT SİLME
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Category soft silindi";
        }
    }
}
