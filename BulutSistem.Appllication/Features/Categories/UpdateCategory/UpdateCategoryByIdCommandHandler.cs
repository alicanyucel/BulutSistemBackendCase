

using AutoMapper;
using BulutSistem.Domain.Models;
using BulutSistem.Domain.Repositories;
using MediatR;
using TS.Result;

namespace BulutSistem.Appllication.Features.Categories.UpdateCategory
{
    internal sealed class UpdateCategoryByIdCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateCategoryByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            Category category = await categoryRepository.GetByExpressionWithTrackingAsync(P => P.Id == request.Id, cancellationToken);
            if (category == null)
            {
                return Result<string>.Failure("kategory yok");
            }
            mapper.Map(request, category);
            categoryRepository.Update(category);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "kategory güncelledi";

        }
    }
}
