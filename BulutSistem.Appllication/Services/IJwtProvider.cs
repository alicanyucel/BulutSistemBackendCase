using BulutSistem.Appllication.Features.Auth.Login;
using BulutSistem.Domain.Models;


namespace BulutSistem.Appllication.Services
{
    public interface IJwtProvider
    {
        Task<LoginCommandResponse> CreateToken(AppUser user);
    }
}
