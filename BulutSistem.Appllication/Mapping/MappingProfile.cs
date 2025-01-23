
using AutoMapper;
using BulutSistem.Appllication.Features.Categories.AddCategory;
using BulutSistem.Appllication.Features.Categories.UpdateCategory;
using BulutSistem.Domain.Models;

namespace BulutSistem.Appllication.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AddCategoryCommad, Category>().ReverseMap(); // best practice two way mapping
            CreateMap<UpdateCategoryByIdCommand, Category>().ReverseMap();
        }
    }
}
