
using AutoMapper;

namespace BulutSistem.Appllication.Mapping
{
    internal class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateMeetCommand, Meet>().ReverseMap();
            CreateMap<UpdateMeetCommand, Meet>().ReverseMap();
        }
    }
}
