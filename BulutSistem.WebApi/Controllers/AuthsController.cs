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
        // loglama
        private readonly ILogger<AuthsController> _logger;
        public AuthsController(IMediator mediator, ILogger<AuthsController> logger) : base(mediator)
        {
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Login işlemine başlandı. Kullanıcı adı: {UserorEmail}", request.UserorEmail);
            try
            {
                var response = await _mediator.Send(request, cancellationToken);
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Login işlemi sırasında hata oluştu. Kullanıcı adı: {UserorEmail}", request.UserorEmail);
                return StatusCode(500, "Bir hata oluştu.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Kullanıcı kaydı başarıyla tamamlandı. Kullanıcı adı veya e-posta: {UserorEmail}", request); 
            try
            {

                await _mediator.Send(request, cancellationToken);
                return NoContent();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "register hata var", request);
                return BadRequest();
            }
        }
    }
}
