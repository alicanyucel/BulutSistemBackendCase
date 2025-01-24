using BulutSistem.Appllication.Features.Auth.Login;
using BulutSistem.Appllication.Features.Auth.Register;
using BulutSistem.Infrastructure.Services;
using BulutSistem.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulutSistem.WebApi.Controllers
{
    [AllowAnonymous]
    public sealed class AuthsController : ApiController
    {
        // serilog
        private readonly ILogger<AuthsController> _logger;
        // redis
        private readonly RedisCacheService _redisCacheService;

        public AuthsController(IMediator mediator, ILogger<AuthsController> logger, RedisCacheService redisCacheService) : base(mediator)
        {
            _logger = logger;
            _redisCacheService = redisCacheService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Login işlemine başlandı. Kullanıcı adı: {UserorEmail}", request.UserorEmail);

            try
            {
              
                var response = await _mediator.Send(request, cancellationToken);

               
                var cacheKey = $"user_session_{request.UserorEmail}";
                var sessionData = $"User: {request.UserorEmail} logged in at {DateTime.UtcNow}";

            
                await _redisCacheService.SetCacheAsync(cacheKey, sessionData, TimeSpan.FromMinutes(5));

               
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
            _logger.LogInformation("Kullanıcı kaydı başarıyla tamamlandı. Kullanıcı adı veya e-posta: {UserorEmail}", request.UserName);

            try
            {
               
                await _mediator.Send(request, cancellationToken);

               
                var cacheKey = $"user_profile_{request.UserName}";
                var profileData = $"User: {request.UserName} registered at {DateTime.UtcNow}";

            
                await _redisCacheService.SetCacheAsync(cacheKey, profileData, TimeSpan.FromHours(1));

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Register sırasında hata oluştu. Kullanıcı adı veya e-posta: {UserorEmail}", request.UserName);
                return BadRequest();
            }
        }
    }

}
