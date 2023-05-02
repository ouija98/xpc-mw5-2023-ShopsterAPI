using AutoMapper;
using Shopster.DAL.Entities;
using Shopster.DTOs;

namespace Shopster.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CategoryDTO, CategoryEntity>();
        CreateMap<CommodityDTO, CommodityEntity>();
        CreateMap<ManufacturerDTO, ManufacturerEntity>();
        CreateMap<RatingDTO, RatingEntity>();
        
        CreateMap<CategoryEntity, CategoryDTO>();
        CreateMap<CommodityEntity, CommodityDTO>();
        CreateMap<ManufacturerEntity, ManufacturerDTO>();
        CreateMap<RatingEntity, RatingDTO>();
    }
}