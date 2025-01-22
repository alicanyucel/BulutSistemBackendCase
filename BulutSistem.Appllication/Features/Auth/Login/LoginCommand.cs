using MediatR;
using TS.Result;

namespace BulutSistem.Appllication.Features.Auth.Login;

public sealed record LoginCommand(
    string UserorEmail,
    string Password) : IRequest<Result<LoginCommandResponse>>;