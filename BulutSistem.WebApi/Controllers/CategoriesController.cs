using BulutSistem.Appllication.Features.Categories.AddCategory;
using BulutSistem.Appllication.Features.Categories.DeleteCategory;
using BulutSistem.Appllication.Features.Categories.GetCategoriy;
using BulutSistem.Appllication.Features.Categories.UpdateCategory;
using BulutSistem.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulutSistem.WebApi.Controllers
{
    [AllowAnonymous]

    public sealed class CategoriesController : ApiController
    {
        public CategoriesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryCommad request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);

        }
        [HttpPost] //bilerek posta çektim
        public async Task<IActionResult> GetAll(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }
        [HttpPost] 
        public async Task<IActionResult> Update(UpdateCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }
    }
}