using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class CartDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int quantity { get; set; }
        public decimal perunitprice { get; set; }
        public decimal Totalprice { get; set; }
    }
}
