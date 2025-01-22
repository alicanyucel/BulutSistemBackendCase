
using BulutSistem.Domain.Models;


namespace BulutSistem.Appllication.Services
{
    public interface IJwtProvider
    {
        string CreateToken(AppUser user);
    }
}
