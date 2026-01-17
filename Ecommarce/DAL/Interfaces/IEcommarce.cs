using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IEcommarce
    {
        public List<Product> AllProductDetails();
        public List<Product> ViewCart();
        public List<Product> AddToCart(Product product);
        public List<Product> RemoveFromCart(Product product);
        public bool PlaceOrder(List<Product> order);
        public string ViewOrderStatus();
    }
}
