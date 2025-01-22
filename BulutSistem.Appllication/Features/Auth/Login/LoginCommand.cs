using MediatR;


namespace BulutSistem.Appllication.Features.Auth.Login;

public sealed record LoginCommand(
string UserNameOrEmail,
string Password) : IRequest<LoginCommandResponse>;
