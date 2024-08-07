using AutoMapper;
using LightWeightValidationAPI.Models;

namespace LightWeightValidationAPI.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDto, Product>();
        }
    }
}
