using MediatR;
using TS.Result;

namespace BulutSistem.Appllication.Features.Products.DeleteProduct
{
    public sealed record DeleteProductByIdCommand(int Id) : IRequest<Result<string>>;
}
