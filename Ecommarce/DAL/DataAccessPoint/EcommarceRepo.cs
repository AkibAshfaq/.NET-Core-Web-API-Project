using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DataAccessPoint
{
    public class EcommarceRepo: IEcommarce
    {
        DataContext db;
        public EcommarceRepo(DataContext db)
        {
            this.db = db;
        }

        private List<Product> MyCart = new List<Product>();

        public List<Product> AddToCart(Product product)
        {
            MyCart.Add(product);
            return MyCart;
        }
        public List<Product> RemoveFromCart(Product product)
        {
            MyCart.Remove(product);
            return MyCart;
        }

        public List<Product> AllProductDetails()
        {
            throw new NotImplementedException();
        }

        public bool PlaceOrder(List<Product> order)
        {
            throw new NotImplementedException();
        }

        

        public List<Product> ViewCart()
        {
            throw new NotImplementedException();
        }

        public string ViewOrderStatus()
        {
            throw new NotImplementedException();
        }
    }
}
