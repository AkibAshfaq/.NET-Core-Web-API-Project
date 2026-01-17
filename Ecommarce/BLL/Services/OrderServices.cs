using BLL.DTOs;
using DAL;
using DAL.EF;
using DAL.EF.Models;
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

        public List<CartDTO> mycart = new List<CartDTO>();

        public List<CartDTO> AddToCart(ProductDTO product)
        {
            CartDTO cart = new CartDTO();
            cart.ProductID = product.ProductId;
            cart.ProductName = product.ProductName;
            cart.Quantity = 1;
            mycart.Add(cart);
            return mycart;
        }

        public List<CartDTO> RemoveFromCart(ProductDTO product)
        {
            CartDTO cart = new CartDTO();
            cart.ProductID = product.ProductId;
            cart.ProductName = product.ProductName;
            cart.Quantity = 1;
            mycart.Remove(cart);
            return mycart;
        }

        public List<CartDTO> UpdateCart(CartDTO product)
        {
            foreach(var item in mycart)
            {
                if(item.ProductID == product.ProductID)
                {
                    item.Quantity = product.Quantity;
                }
            }
            return mycart;
        }

        public List<CartDTO> ViewCart()
        {
            return mycart;
        }

        public List<CartDTO> AddToCartById(int productId)
        {
            Product pd = pdservice.ProductById(productId);
            ProductDTO dto = AutoMapper.GetMapper().Map<ProductDTO>(pd);
            return AddToCart(dto);
        }
        public List<CartDTO> RemoveFromCartById(int productId)
        {
            foreach (var item in mycart)
            {
                if (item.ProductID == productId)
                {
                    mycart.Remove(item);
                }
            }
            return mycart;
        }


    }
}
