﻿

using MediatR;
using TS.Result;

namespace BulutSistem.Appllication.Features.Variants.AddVariants
{
   public sealed record AddVariantCommand(int?CategoryId,string Name,decimal Price,int ProductId,int StockQuantity):IRequest<Result<string>>;

}
