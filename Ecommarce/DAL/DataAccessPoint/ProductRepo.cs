using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;

namespace DAL.DataAccessPoint
{
    public class ProductRepo : IRepository<Product>
    {
        DataContext db;

        public ProductRepo(DataContext db)
        {
            this.db = db;
        }

        public bool CreateProduct(Product pd)
        {
            db.Products.Add(pd);
            return db.SaveChanges() > 0;
        }

        public bool DeleteProduct(int id)
        {
            var DeleteProduct = db.Products.Find(id);
            if(DeleteProduct == null)
            {
                return false;
            }
            db.Products.Remove(DeleteProduct);
            return db.SaveChanges() > 0;
        }

        public bool UpdateProduct(Product pd)
        {
            var extprod = db.Products.Find(pd.ProductId);
            if(extprod == null)
            {
                return false;
            }
            db.Entry(extprod).CurrentValues.SetValues(pd);
            return db.SaveChanges() > 0;
        }

        public Product GetProductById(int id)
        {
            var product = db.Products.Find(id);
            if(product == null)
            {
                return new Product();
            }
            return product;
        }

        public Product GetProductByName(string name)
        {
            var product = (from p in db.Products
                           where p.ProductName.Contains(name)
                           select p).SingleOrDefault();
            if (product == null)
                return new Product();
            return product;
        }

        public List<Product> GetAllProducts()
        {
            var products = db.Products.ToList();
            return products;
        }
    }
}
