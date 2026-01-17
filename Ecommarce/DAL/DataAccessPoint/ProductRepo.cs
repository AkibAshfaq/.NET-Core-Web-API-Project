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
            db.Products.Remove(DeleteProduct);
            return db.SaveChanges() > 0;
        }

        public bool UpdateProduct(Product pd)
        {
            var extprod = db.Products.Find(pd.Id);
            db.Entry(extprod).CurrentValues.SetValues(pd);
            return db.SaveChanges() > 0;
        }

        public Product GetProductById(int id)
        {
            return db.Products.Find(id);
        }

        public Product GetProductByName(string name)
        {
            var product = (from p in db.Products
                           where p.Name.Contains(name)
                           select p).SingleOrDefault();
            return product;
        }

        public List<Product> GetAllProducts()
        {
            var products = (from p in db.Products
                            select p).ToList();
            return products;
        }
    }
}
