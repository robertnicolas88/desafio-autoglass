using AutoMapper;
using DesafioAutoGlass.Core.Entities;
using DesafioAutoGlass.Application.DTOs;

namespace DesafioAutoGlass.Application.Mappings
{
    public class Mapping : Profile
    {
        public Mapping() 
        {
            CreateMap<ProductDto, Product>()
                .ReverseMap();
        }
    }
}
