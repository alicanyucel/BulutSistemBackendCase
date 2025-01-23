using Azure.Core;
using BulutSistem.Appllication.Features.Categories.AddCategory;
using BulutSistem.Appllication.Features.Categories.DeleteCategory;
using BulutSistem.Appllication.Features.Categories.GetCategoriy;
using BulutSistem.Appllication.Features.Categories.UpdateCategory;
using BulutSistem.Infrastructure.Services;
using BulutSistem.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulutSistem.WebApi.Controllers
{
    [AllowAnonymous] // deneme amaclı izin verdim

    public sealed class CategoriesController : ApiController
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly RedisCacheService _redisCacheService;
        public CategoriesController(IMediator mediator,ILogger<CategoriesController> logger,RedisCacheService redisCacheService) : base(mediator)
        {
            _logger=logger;
            _redisCacheService=redisCacheService;
        }
        [Authorize(Roles = "Admin,Editor")]
        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Category ekleme işlemine başlandı");
            try { 
            var response = await _mediator.Send(request, cancellationToken);
                var cacheKey = $"category_{request}";
                var sessionData = $"Category: {request} logged in at {DateTime.UtcNow}";
                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ekleme işlemi sırasında hata oluştu", request);
                return StatusCode(500, "Bir hata oluştu.");
            }

        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Category silme işlemine başlandı");
            try
            {
                var response = await _mediator.Send(new DeleteCategoryByIdCommand(id), cancellationToken);
                var cacheKey = $"categorydelete_{new DeleteCategoryByIdCommand(id)}";
                var sessionData = $"Category: {new DeleteCategoryByIdCommand(id)} logged in at {DateTime.UtcNow}";
                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex) {
                return StatusCode(500,"hata oluştu");
            }

        }
        [Authorize(Roles = "Admin,Editor,Viewe")]
        [HttpPost] //bilerek posta çektim
        public async Task<IActionResult> GetAll(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Category listeleme işlemine başlandı");
            try
            {
                var response = await _mediator.Send(request, cancellationToken);
                var cacheKey = $"categoryadd_{request}";
                var sessionData = $"Category: {request} logged in at {DateTime.UtcNow}";
                return Ok(response);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, "hata var");
            }
        }
        [Authorize(Roles = "Admin,Editor")]
        [HttpPut] // endpoint bu şekilde durmalı
        public async Task<IActionResult> Update(UpdateCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Category update işlemine başlandı");
            try
            {
                var response = await _mediator.Send(request, cancellationToken);
                var cacheKey = $"categoryUpdate_{request}";
                var sessionData = $"CategoryUpdate: {request} logged in at {DateTime.UtcNow}";
                return Ok(response);
            }
            catch (Exception ex) 
            {
                return StatusCode(500,"hata var");
            }
        }
    }
}