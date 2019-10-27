using System;
using System.ComponentModel.DataAnnotations;
using AddressBook.Contracts.Validation;

namespace AddressBook.Contracts.Models
{
    /// <summary>
    /// Contact model extended with unique identifier.
    /// </summary>
    public class ContactWithId
        : Contact
    {
        [Required]
        [NotEmpty]
        public Guid Id { get; set; }
    }
}
