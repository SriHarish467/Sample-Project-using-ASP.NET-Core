using AutoMapper;
using Product.Domain;
using Product.Service.Dto;

namespace Product.Service.Helpers
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductDetailDto, ProductDetail>().ReverseMap();
            CreateMap<PriceDetailDto, PriceDetail>().ReverseMap();
        }
    }
}
