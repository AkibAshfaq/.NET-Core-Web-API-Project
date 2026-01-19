using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BLL.DTOs
{
    public class OrderDetailDTO
    {
        public int OrdersID { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmmount { get; set; }
        public string PaymentMethod { get; set; }
    }
}
