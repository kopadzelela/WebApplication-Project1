using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication_Project1.DataAccess
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
            Warehouses = new HashSet<Warehouse>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Code { get; set; } = null!;
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [Column("CategoryID")]
        public int CategoryId { get; set; }
        [Column("ProductCategoriesID")]
        public int ProductCategoriesId { get; set; }
        [Column("Rec. for ages 3 and under")]
        [StringLength(10)]
        [Unicode(false)]
        public string? RecForAges3AndUnder { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Products")]
        public virtual Category Category { get; set; } = null!;
        [ForeignKey(nameof(ProductCategoriesId))]
        [InverseProperty(nameof(ProductCategory.Products))]
        public virtual ProductCategory ProductCategories { get; set; } = null!;
        [InverseProperty(nameof(OrderItem.Product))]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        [InverseProperty(nameof(Warehouse.Product))]
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
