using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication_Project1.DataAccess
{
    public partial class Supplier
    {
        public Supplier()
        {
            Warehouses = new HashSet<Warehouse>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        public int CompanyCode { get; set; }
        [StringLength(50)]
        public string CompanyName { get; set; } = null!;
        [StringLength(50)]
        public string ContactFullName { get; set; } = null!;
        [Column("CityID")]
        public int CityId { get; set; }
        [Column("CountryID")]
        public int CountryId { get; set; }
        [Column("phone")]
        public int Phone { get; set; }
        [StringLength(50)]
        public string? Fax { get; set; }
        [StringLength(500)]
        public string? WebSite { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty("Suppliers")]
        public virtual City City { get; set; } = null!;
        [ForeignKey(nameof(CountryId))]
        [InverseProperty("Suppliers")]
        public virtual Country Country { get; set; } = null!;
        [InverseProperty(nameof(Warehouse.Supplier))]
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
