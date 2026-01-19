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

            var ext = mycart.Find(item => item.ProductId == product.ProductId);
            if (ext != null)
            {
                ext.quantity += 1;
                ext.Totalprice = ext.perunitprice * ext.quantity;
                return mycart;
            }

            var MAP = AutoMapper.GetMapper().Map<CartDTO>(product);

            mycart.Add(MAP);
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

        public List<CartDTO> DecreaseOneById(int product)
        {
            var ext = mycart.Find(item => item.ProductId == product);
            if (ext != null)
            {
                if(ext.quantity >= 0)
                {
                    ext.quantity -= 1;
                    ext.Totalprice = ext.perunitprice * ext.quantity;
                    return mycart;
                }
                else
                {
                    return RemoveFromCartById(product) ? mycart : mycart;
                }    
            }

            return mycart;
        }

        public bool RemoveFromCartById(int productId)
        {
            return mycart.RemoveAll(item => item.ProductId == productId) > 0;
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

        public decimal TotalCost()
        {
            decimal total = 0;
            foreach (var item in mycart)
            {
                total += item.Totalprice;
            }
            return total;
        }


       public ProductDTO SearchProduct(string ProductName)
        {
            ProductDTO dto = pdservice.ProductByName(ProductName);
            if (dto == null)
            {
                return new ProductDTO();
            }
            return dto;
        }

        public List<OrderDetailDTO> GetOrderById(int id)
        {
            List<OrderDetail> order = factory.EcommarceFeature().GetOrderById(id);
            List<OrderDetailDTO> dto = AutoMapper.GetMapper().Map<List<OrderDetailDTO>>(order);
            return dto;
        }
        
        public bool PlaceOrder(string pay)
        {
            foreach(var item in mycart)
            {
                OrderDTO orderdto = new OrderDTO
                {
                    CustomerId = 1,
                    ProductId = item.ProductId,
                    quantity = item.quantity,
                    perunitprice = item.perunitprice,
                    Totalprice = item.Totalprice
                };
                Order order = AutoMapper.GetMapper().Map<Order>(orderdto);
                factory.EcommarceFeature().AddToOrder(order);
            }

            OrderDetailDTO orderdetaildto = new OrderDetailDTO
            {
                CustomerId = 1,
                TotalAmmount = TotalCost(),
                PaymentMethod = pay
            };
            OrderDetail orderdetail = AutoMapper.GetMapper().Map<OrderDetail>(orderdetaildto);
            factory.EcommarceFeature().PaymentGatway(orderdetail);

            ClearCart();
            return true;
        }

    }
}
