using BulutSistem.Appllication.Features.Categories.DeleteCategory;
using BulutSistem.Appllication.Features.Products.AddProduct;
using BulutSistem.Appllication.Features.Products.DeleteProduct;
using BulutSistem.Appllication.Features.Products.GetProduct;
using BulutSistem.Appllication.Features.Products.UpdateProduct;
using BulutSistem.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulutSistem.WebApi.Controllers
{
    [AllowAnonymous]
    public class ProductsController : ApiController
    {
        public ProductsController(IMediator mediator) : base(mediator)
        {

        }
       
        [HttpPost]
        public async Task<IActionResult> Create(AddProductCommand request, CancellationToken cancellationToken)
        {

            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductById(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeleteProductByIdCommand(id), cancellationToken);
            return StatusCode(response.StatusCode, response);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductById(UpdateProductByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);

        }

    }
}
