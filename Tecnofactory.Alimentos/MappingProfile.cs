using AutoMapper;
using Tecnofactory.Alimentos.DAL.Entity;
using Tecnofactory.Alimentos.DTO;

namespace Tecnofactory.Alimentos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FoodDto, Catalogue>().ReverseMap();
            CreateMap<UserOrderDto, Order>().ReverseMap();
        }
    }
}
