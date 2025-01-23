using BulutSistem.Appllication.Features.Products.UpdateProduct;
using BulutSistem.Appllication.Features.Variants.AddVariants;
using BulutSistem.Appllication.Features.Variants.DeleteVaritants;
using BulutSistem.Appllication.Features.Variants.GetAllVariants;
using BulutSistem.Appllication.Features.Variants.UpdateVaritants;
using BulutSistem.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulutSistem.WebApi.Controllers
{
    [AllowAnonymous]
    public class VariantsController : ApiController
    {
        public VariantsController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddVariantCommand request, CancellationToken cancellationToken)
        {

            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> GetAll([FromQuery] GetAllVariantQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVariantById(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeleteVariantByIdCommand(id), cancellationToken);
            return StatusCode(response.StatusCode, response);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateVariantById(UpdateVariantByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);

        }
    }
}
