using Microsoft.EntityFrameworkCore;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option) : base(option)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


    }
}
