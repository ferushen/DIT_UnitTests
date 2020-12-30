using AutoMapper;
using Database.EFCore.Entities;

namespace WebApp.EFCore
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<BookEntity, Books>()
                .ForMember(
                    dst => dst.id, 
                    opt => opt.MapFrom(src => src.id))
                .ForMember(
                    dst => dst.name,
                    opt => opt.MapFrom(src => src.name))
                .ForMember(
                    dst => dst.author,
                    opt => opt.MapFrom(src => src.author))
                .ForMember(
                    dst => dst.year,
                    opt => opt.MapFrom(src => src.year));                
        }
    }
}