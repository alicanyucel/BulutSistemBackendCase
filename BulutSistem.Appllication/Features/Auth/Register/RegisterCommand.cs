using MediatR;


namespace BulutSistem.Appllication.Features.Auth.Register;

public  record RegisterCommand(
 string Name,
 string Lastname,
 string Email,
 string UserName,
 string Password,
 string PhoneNumber
) : IRequest<Unit>;
