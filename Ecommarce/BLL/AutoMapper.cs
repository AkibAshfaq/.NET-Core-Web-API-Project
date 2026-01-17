using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;

namespace BLL
{
    public class AutoMapper
    {
        static MapperConfiguration cf = new MapperConfiguration( c =>{

            c.CreateMap<ProductDTO, Product>().ReverseMap();
        
        });

        public static Mapper GetMapper()
        {
            return new Mapper(cf);
        }

    }
}
