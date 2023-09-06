using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public string  CustomerName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool IsDelete { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}
