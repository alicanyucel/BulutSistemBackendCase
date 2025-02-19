﻿using BulutSistem.Appllication.Features.Role;
using BulutSistem.WebApi.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulutSistem.WebApi.Controllers
{
    [AllowAnonymous]
    public sealed class RolesController : ApiController
    {
        public RolesController(IMediator mediator) : base(mediator)
        {
        }

        // sadece admin viever editor rollerini oluşuuryor rol tablosuna ekliyor birşey yazmıyoruz
        [HttpPost]
        public async Task<IActionResult> Sync(RoleSyncCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response.Data);
        }
    }
}