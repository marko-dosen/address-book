using AddressBook.Domain.Models;
using BoundaryContact = AddressBook.Contracts.Models.Contact;

namespace AddressBook.App.Mapping
{
    public static class ContactFactory
    {
        public static Contact CreateDomainContact(this BoundaryContact contact)
            => new Contact(
                contact.Name,
                contact.DateOfBirth,
                CreateDomainAddress(contact),
                contact.PhoneNumbers);

        private static Address CreateDomainAddress(BoundaryContact contact)
            => new Address(
                contact.Address.AddressLine1,
                contact.Address.AddressLine2,
                contact.Address.AddressLine3,
                contact.Address.City,
                contact.Address.State,
                contact.Address.Zip,
                contact.Address.Country
            );
    }
}
