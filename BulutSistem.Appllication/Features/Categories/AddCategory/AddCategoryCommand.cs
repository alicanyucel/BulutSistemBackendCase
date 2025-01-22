

namespace BulutSistem.Appllication.Features.Categories.AddCategory;

public sealed record AddCategoryCommad(string Name,string? Description,decimal Price,int StockQuantity,int CategoryId,bool IsDeleted,int ProductVariantsId);
