using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication_Project1.DataAccess
{
    public partial class Customer
    {
        public Customer()
        {
            CustomersPhoneNumbers = new HashSet<CustomersPhoneNumber>();
            CustomersRelationshipEndCustomers = new HashSet<CustomersRelationship>();
            CustomersRelationshipStartCustomers = new HashSet<CustomersRelationship>();
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        [Column("GenderID")]
        public int GenderId { get; set; }
        [StringLength(11)]
        [Unicode(false)]
        public string PersonalNumber { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }
        [Column("CityID")]
        public int CityId { get; set; }
        [Column("CountryID")]
        public int CountryId { get; set; }
        [StringLength(50)]
        public string Email { get; set; } = null!;
        [StringLength(10)]
        [Unicode(false)]
        public string? StartCustomer { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string? EndCustomer { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty("Customers")]
        public virtual City City { get; set; } = null!;
        [ForeignKey(nameof(CountryId))]
        [InverseProperty("Customers")]
        public virtual Country Country { get; set; } = null!;
        [ForeignKey(nameof(GenderId))]
        [InverseProperty("Customers")]
        public virtual Gender Gender { get; set; } = null!;
        [InverseProperty(nameof(CustomersPhoneNumber.Customer))]
        public virtual ICollection<CustomersPhoneNumber> CustomersPhoneNumbers { get; set; }
        [InverseProperty(nameof(CustomersRelationship.EndCustomer))]
        public virtual ICollection<CustomersRelationship> CustomersRelationshipEndCustomers { get; set; }
        [InverseProperty(nameof(CustomersRelationship.StartCustomer))]
        public virtual ICollection<CustomersRelationship> CustomersRelationshipStartCustomers { get; set; }
        [InverseProperty(nameof(Order.Customer))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
