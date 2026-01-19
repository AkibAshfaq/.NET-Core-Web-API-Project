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

        public List<Product> ByCategoryProductDetails(string Category)
        {
            return db.Products.Where(p => p.ProductCategory == Category).ToList();
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

        public void AddToOrder(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }

        public void PaymentGatway(OrderDetail order)
        {
            db.OrderDetails.Add(order);
            db.SaveChanges();
        }

        public List<OrderDetail> GetOrderById(int id)
        {
            List<OrderDetail> orderDetail = db.OrderDetails.Where( c => c.CustomerId == id).ToList();
            return orderDetail;
        }
        public OrderDetail GetOrderByCustomerId(int id)
        {
            var orderDetail = db.OrderDetails.Where(o => o.CustomerId == id).FirstOrDefault();
            if (orderDetail != null)
            {
                return orderDetail;
            }
            return new OrderDetail();
        }

        public int CheckStock(int productId)
        {
            var product = db.Products.Where(p => p.ProductId == productId).FirstOrDefault();
            if (product != null)
            {
                return product.ProductStock;
            }
            return 0;
        }

    }
}
