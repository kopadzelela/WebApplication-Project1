using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication_Project1.DataAccess
{
    public partial class OrderItem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column("ProductID")]
        public int ProductId { get; set; }
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }
        [StringLength(10)]
        public string IsDiscounter { get; set; } = null!;
        public double DiscountPrice { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("OrderItems")]
        public virtual Order Order { get; set; } = null!;
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("OrderItems")]
        public virtual Product Product { get; set; } = null!;
    }
}
