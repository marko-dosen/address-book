using System;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Contracts.Models
{
    /// <summary>
    /// Base contact model.
    /// </summary>
    public class Contact
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public Address Address { get; set; }

        [Required]
        [MinLength(1)]
        public string[] PhoneNumbers { get; set; } = new string[0];
    }
}
