using AutoMapper;
using FluentValidationAPI.Models;

namespace FluentValidationAPI.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDto, Product>();
        }
    }
}
