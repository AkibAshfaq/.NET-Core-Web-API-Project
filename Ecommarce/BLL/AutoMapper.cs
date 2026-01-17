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

        });

        public static Mapper GetMapper()
        {
            return new Mapper(cf);
        }

    }
}
