using System.Linq;
using AddressBook.Domain.Models;
using AddressBook.Persistence.Models;

namespace AddressBook.Persistence.Mapping
{
    public static class ContactFactory
    {
        public static Contact CreateDomainContact(this DbContact contact)
            => new Contact(
                contact.Id,
                contact.Name,
                contact.DateOfBirth,
                CreateDomainAddress(contact),
                CreateDomainPhoneNumbers(contact));

        private static Address CreateDomainAddress(DbContact contact)
            => new Address(
                contact.AddressLine1,
                contact.AddressLine2,
                contact.AddressLine3,
                contact.City,
                contact.State,
                contact.Zip,
                contact.Country
                );

        private static string[] CreateDomainPhoneNumbers(DbContact contact)
            => contact.PhoneNumbers.Select(p => p.Value).ToArray();
    }
}
