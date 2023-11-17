using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication_Project1.DataAccess
{
    [Table("Warehouse")]
    public partial class Warehouse
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime OperationDate { get; set; }
        [StringLength(50)]
        public string DokNumber { get; set; } = null!;
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Column("SupplierID")]
        public int SupplierId { get; set; }
        [Column("UnitID")]
        public int UnitId { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "date")]
        public DateTime ExipryDate { get; set; }
        public double UnitPrice { get; set; }
        public double RealizationPrice { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("Warehouses")]
        public virtual Product Product { get; set; } = null!;
        [ForeignKey(nameof(SupplierId))]
        [InverseProperty("Warehouses")]
        public virtual Supplier Supplier { get; set; } = null!;
        [ForeignKey(nameof(UnitId))]
        [InverseProperty("Warehouses")]
        public virtual Unit Unit { get; set; } = null!;
    }
}
