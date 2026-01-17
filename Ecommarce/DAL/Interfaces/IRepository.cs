using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetAllProducts();
        T GetProductById(int id);
        T GetProductByName(string name);
        public bool CreateProduct(T pd);
        public bool UpdateProduct(T pd);
        public bool DeleteProduct(int id);
    }
}
