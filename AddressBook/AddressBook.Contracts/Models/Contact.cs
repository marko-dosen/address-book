using System;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Contracts.Models
{
    public class Contact
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public Address Address { get; set; }

        public string[] PhoneNumbers { get; set; }
    }
}
