using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication_Project1.DataAccess
{
    public partial class Unit
    {
        public Unit()
        {
            Warehouses = new HashSet<Warehouse>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [StringLength(50)]
        public string ShortName { get; set; } = null!;

        [InverseProperty(nameof(Warehouse.Unit))]
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
