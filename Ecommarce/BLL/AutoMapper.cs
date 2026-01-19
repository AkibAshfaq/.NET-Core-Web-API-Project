using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;

namespace BLL
{
    public class AutoMapper
    {
        static MapperConfiguration cf = new MapperConfiguration( c =>{

            c.CreateMap<ProductDTO, Product>().ReverseMap();
            c.CreateMap<CustomerDTO, Customer>().ReverseMap();
            c.CreateMap<OrderDTO, Order>().ReverseMap();
            c.CreateMap<OrderDetailDTO, OrderDetail>().ReverseMap();
            c.CreateMap<CartDTO, ProductDTO>().ReverseMap().ForMember(
                dest => dest.Totalprice,
                opt => opt.MapFrom(src => src.ProductPrice)
            ).ForMember(
                dest => dest.perunitprice,
                opt => opt.MapFrom(src => src.ProductPrice)
            ).ForMember(
                dest => dest.quantity,
                opt => opt.MapFrom(src => 1)
            );
        });

        public static Mapper GetMapper()
        {
            return new Mapper(cf);
        }

    }
}
