using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class ProductServices
    {

        DataFactory factory;

        public ProductServices(DataFactory factory)
        {
            this.factory = factory;
        }


        public List<ProductDTO> AllProducts()
        {
            var prod = factory.ProductFeature().GetAllProducts();
            var dto = AutoMapper.GetMapper().Map<List<ProductDTO>>(prod);
            return dto;
        }

        public ProductDTO ProductById(int id)
        {
            Product byid = factory.ProductFeature().GetProductById(id);
            ProductDTO dto = AutoMapper.GetMapper().Map<ProductDTO>(byid);
            return dto;
        }

        public ProductDTO ProductByName(string name)
        {
            Product byname = factory.ProductFeature().GetProductByName(name);
            ProductDTO dto = AutoMapper.GetMapper().Map<ProductDTO>(byname);
            return dto;
        }

        public bool AddProduct(ProductDTO product)
        {
            Product prod = AutoMapper.GetMapper().Map<Product>(product);
            return factory.ProductFeature().CreateProduct(prod);
            
        }

        public bool UpdateProduct(ProductDTO product)
        {
            Product prod = AutoMapper.GetMapper().Map<Product>(product);
            var save = factory.ProductFeature().UpdateProduct(prod);
            return save;
        }

        public bool DeleteProduct(int id)
        {
            var repo = factory.ProductFeature();
            return repo.DeleteProduct(id);
        }

    }
}
