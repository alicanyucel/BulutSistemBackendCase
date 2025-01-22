using BulutSistem.Appllication.Features.Auth.Login;
using BulutSistem.Appllication.Features.Auth.Register;
using BulutSistem.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulutSistem.WebApi.Controllers
{
    [AllowAnonymous]
    public sealed class AuthsController : ApiController
    {
        public AuthsController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(200,response);
        }
        
        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterCommand request, CancellationToken cancellationToken)
        {

            await _mediator.Send(request, cancellationToken);
            return NoContent();
        }
    }
}
