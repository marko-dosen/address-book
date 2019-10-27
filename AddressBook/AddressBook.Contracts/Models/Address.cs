using System.ComponentModel.DataAnnotations;
using AddressBook.Contracts.Validation;

namespace AddressBook.Contracts.Models
{
    /// <summary>
    /// Base address model.
    /// </summary>
    public class Address
    {
        [Required]
        [StringLength(50)]
        public string AddressLine1 { get; set; }
        
        [StringLength(50)]
        public string AddressLine2 { get; set; }
        
        [StringLength(50)]
        public string AddressLine3 { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string State { get; set; }

        [Required]
        [StringLength(15)]
        public string Zip { get; set; }

        [Required]
        [CountryCode]
        public string Country { get; set; }
    }
}
