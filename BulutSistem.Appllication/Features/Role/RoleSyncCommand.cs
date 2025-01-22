using MediatR;
using TS.Result;

namespace BulutSistem.Appllication.Features.Role
{
    public sealed record RoleSyncCommand() : IRequest<Result<string>>;
}
