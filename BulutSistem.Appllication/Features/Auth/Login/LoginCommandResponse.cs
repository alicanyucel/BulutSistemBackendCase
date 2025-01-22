

namespace BulutSistem.Appllication.Features.Auth.Login;

public sealed record LoginCommandResponse(
string AccessToken,
Guid UserId);
