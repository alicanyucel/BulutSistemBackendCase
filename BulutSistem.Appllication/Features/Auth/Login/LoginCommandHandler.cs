using BulutSistem.Appllication.Services;
using BulutSistem.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace BulutSistem.Appllication.Features.Auth.Login
{
    internal sealed class LoginCommandHandler(UserManager<AppUser> userManager, IJwtProvider jwtProvider) : IRequestHandler<LoginCommand, Result<LoginCommandResponse>>
    {
        public async Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            AppUser? appUser = await userManager.Users.FirstOrDefaultAsync(p => p.UserName == request.UserorEmail || p.Email == request.UserorEmail, cancellationToken);
            if (appUser is null)
            {
                return Result<LoginCommandResponse>.Failure("user not found");
            }
            Boolean isPasswordCorrect = await userManager.CheckPasswordAsync(appUser, request.Password);
            if (!isPasswordCorrect)
            {
                return Result<LoginCommandResponse>.Failure("password is wrong");
            }
            string token = jwtProvider.CreateToken(appUser);
            LoginCommandResponse response = new(token);
            return Result<LoginCommandResponse>.Succeed(response);
        }
    }
}