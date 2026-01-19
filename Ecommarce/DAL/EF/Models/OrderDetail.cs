using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.EF.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrdersID { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public decimal TotalAmmount { get; set; }
        public string PaymentMethod { get; set; }
    }
}
