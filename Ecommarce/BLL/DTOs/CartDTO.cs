using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class CartDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
