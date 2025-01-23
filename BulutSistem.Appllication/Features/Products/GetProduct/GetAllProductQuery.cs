using BulutSistem.Domain.Models;
using MediatR;


namespace BulutSistem.Appllication.Features.Products.GetProduct
{
    public sealed record GetAllProductQuery() : IRequest<List<Product>>;
}
