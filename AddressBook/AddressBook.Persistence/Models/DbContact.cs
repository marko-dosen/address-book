using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Persistence.Models
{
    [Table("Contact")]
    public class DbContact
    {
        public int Id { get; set; }

        public Guid Reference { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string AddressLine1 { get; set; }
        
        [Column(TypeName = "VARCHAR(50)")]
        public string AddressLine2 { get; set; }
        
        [Column(TypeName = "VARCHAR(50)")]
        public string AddressLine3 { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string City { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string State { get; set; }

        [Column(TypeName = "VARCHAR(15)")]
        public string Zip { get; set; }

        [Column(TypeName = "VARCHAR(3)")]
        public string Country { get; set; }

        public virtual ICollection<DbPhoneNumber> PhoneNumbers { get; set; }

        public DbContact()
        {
            PhoneNumbers = new List<DbPhoneNumber>();
        }
    }
}
