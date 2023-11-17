using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication_Project1.DataAccess
{
    public partial class RelationshipType
    {
        public RelationshipType()
        {
            CustomersRelationships = new HashSet<CustomersRelationship>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [InverseProperty(nameof(CustomersRelationship.RelationshipType))]
        public virtual ICollection<CustomersRelationship> CustomersRelationships { get; set; }
    }
}
