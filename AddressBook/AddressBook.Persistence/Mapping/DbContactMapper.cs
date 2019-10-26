using System.Collections.Generic;
using System.Linq;
using AddressBook.Domain.Models;
using AddressBook.Persistence.Models;

namespace AddressBook.Persistence.Mapping
{
    public static class DbContactMapper
    {
        public static DbContact MapToDbContact(this Contact contact)
        {
            var dbContact = new DbContact();
            dbContact.Id = contact.Id;
            dbContact.AddressLine1 = contact.Address?.AddressLine1;
            dbContact.AddressLine2 = contact.Address?.AddressLine2;
            dbContact.AddressLine3 = contact.Address?.AddressLine3;
            dbContact.City = contact.Address?.City;
            dbContact.State = contact.Address?.State;
            dbContact.Country = contact.Address?.Country;
            dbContact.Zip = contact.Address?.Zip;
            dbContact.Name = contact.Name;
            dbContact.DateOfBirth = contact.DateOfBirth;
            dbContact.PhoneNumbers = MapPhoneNumbers(contact.PhoneNumbers);
            return dbContact;
        }

        private static ICollection<DbPhoneNumber> MapPhoneNumbers(List<string> contactPhoneNumbers)
            => contactPhoneNumbers.Select(p => new DbPhoneNumber { Value = p }).ToList();

    }
}
