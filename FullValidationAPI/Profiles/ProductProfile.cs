using AutoMapper;
using FullValidationAPI.Models;

namespace FullValidationAPI.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDto, Product>();
        }
    }
}
