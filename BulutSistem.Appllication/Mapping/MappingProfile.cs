
using AutoMapper;
using BulutSistem.Appllication.Features.Categories.AddCategory;
using BulutSistem.Appllication.Features.Categories.UpdateCategory;
using BulutSistem.Appllication.Features.Products.AddProduct;
using BulutSistem.Appllication.Features.Products.UpdateProduct;
using BulutSistem.Appllication.Features.Variants.AddVariants;
using BulutSistem.Appllication.Features.Variants.UpdateVaritants;
using BulutSistem.Domain.Models;

namespace BulutSistem.Appllication.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AddProductCommand, Product>().ReverseMap(); // best practice two way mapping
            CreateMap<UpdateProductByIdCommand, Product>().ReverseMap();

            CreateMap<AddVariantCommand, Variant>().ReverseMap(); // best practice two way mapping
            CreateMap<UpdateVariantByIdCommand, Variant>().ReverseMap();

            CreateMap<AddCategoryCommand, Category>().ReverseMap(); // best practice two way mapping
            CreateMap<UpdateCategoryByIdCommand, Category>().ReverseMap();
        }
    }
}
