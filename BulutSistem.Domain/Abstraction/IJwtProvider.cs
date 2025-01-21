

using BulutSistem.Domain.Models;

namespace BulutSistem.Domain.Abstraction;
public interface IJwtProvider
{
    Task<string> CreateTokenAsync(AppUser user);
}