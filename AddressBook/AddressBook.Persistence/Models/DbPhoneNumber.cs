using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Persistence.Models
{
    [Table("PhoneNumber")]

    public class DbPhoneNumber
    {
        public int Id { get; set; }

        [Column (TypeName = "VARCHAR(30)")]
        public string Value { get; set; }

        public int ContactId { get; set; }

        public virtual DbContact Contact { get; set; }
    }
}
