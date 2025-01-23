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
    [AllowAnonymous] // deneme amaclı izin verdim

    public sealed class CategoriesController : ApiController
    {
        public CategoriesController(IMediator mediator) : base(mediator)
        {
        }
        [Authorize(Roles = "Admin,Editor")]
        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryCommad request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);

        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeleteCategoryByIdCommand(id), cancellationToken);
            return StatusCode(response.StatusCode, response);

        }
        [Authorize(Roles = "Admin,Editor,Viewe")]
        [HttpPost] //bilerek posta çektim
        public async Task<IActionResult> GetAll(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }
        [Authorize(Roles = "Admin,Editor")]
        [HttpPut] // endpoint bu şekilde durmalı
        public async Task<IActionResult> Update(UpdateCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }
    }
}