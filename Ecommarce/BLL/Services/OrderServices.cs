using BLL.DTOs;
using DAL;
using DAL.EF;
using DAL.EF.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class OrderServices
    {
        ProductServices pdservice;

        DataFactory factory;

        public OrderServices(DataFactory factory, ProductServices pdservice)
        {
            this.factory = factory;
            this.pdservice = pdservice;
        }

        public static List<CartDTO> mycart = new List<CartDTO>();

        public List<CartDTO> AddToCart(ProductDTO product)
        {
            if (product == null)
            {
                return new List<CartDTO>();
            }

            var ext = mycart.Find(item => item.ProductID == product.ProductId);
            if (ext != null)
            {
                ext.Quantity += 1;
                ext.TotalPrice = ext.PerUnitPrice * ext.Quantity;
                return mycart;
            }

            CartDTO cart = new CartDTO {
                ProductID = product.ProductId,
                ProductName = product.ProductName,
                Quantity = 1,
                PerUnitPrice = product.ProductPrice,
                TotalPrice = product.ProductPrice
            };
            mycart.Add(cart);
            return mycart;
        }

        public List<CartDTO> ViewCart()
        {
            return mycart;
        }

        public List<CartDTO> AddToCartById(int productId)
        {
            ProductDTO dto = pdservice.ProductById(productId);
            if (dto == null)
            {
                return new List<CartDTO>();
            }

            return AddToCart(dto);
        }

        public bool RemoveFromCartById(int productId)
        {
            return mycart.RemoveAll(item => item.ProductID == productId) > 0;
        }

        public List<CartDTO> AddToCartByName(string ProductName)
        {
            ProductDTO dto = pdservice.ProductByName(ProductName);
            if( dto == null)
            {
                return new List<CartDTO>();
            }
            return AddToCart(dto);
        }
        public bool RemoveFromCartByName(string ProductName)
        {
            return mycart.RemoveAll(item => item.ProductName == ProductName) > 0;
        }

        public List<ProductDTO> ProductByCategory(string Category)
        {
            var filter = factory.EcommarceFeature().ByCategoryProductDetails(Category);
            var dto = AutoMapper.GetMapper().Map<List<ProductDTO>>(filter);
            return dto;
        }


        public bool ClearCart()
        {
            mycart.Clear();
            return mycart.Count == 0;
        }

        public Decimal TotalCost()
        {
            Decimal total = 0;
            foreach (var item in mycart)
            {
                total += item.TotalPrice;
            }
            return total;
        }


    }
}
