using System;
using AddressBook.Contracts.Models;
using Contact = AddressBook.Domain.Models.Contact;

namespace AddressBook.App.Mapping
{
    public static class ContactWithIdFactory
    {
        public static ContactWithId CreateContactWithId(this Contact contact)
            =>new ContactWithId
            {
                Address = CreateAddress(contact?.Address),
                Name = contact?.Name,
                PhoneNumbers = contact?.PhoneNumbers.ToArray(),
                Id = contact?.Id ?? Guid.Empty,
                DateOfBirth = contact?.DateOfBirth ?? new DateTime()
            };

        private static Address CreateAddress(Domain.Models.Address address)
            => new Address
            {
                State = address?.State,
                Country = address?.Country,
                Zip = address?.Zip,
                City = address?.City,
                AddressLine1 = address?.AddressLine1,
                AddressLine2 = address?.AddressLine2,
                AddressLine3 = address?.AddressLine3
            };
    }
}
