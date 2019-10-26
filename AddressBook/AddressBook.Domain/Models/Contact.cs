using System;
using System.Collections.Generic;
using AddressBook.Domain.Helpers;
using AddressBook.Domain.Kernel;

namespace AddressBook.Domain.Models
{
    public class Contact
        : Entity<Guid>
    {
        public string Name { get; }

        public DateTime DateOfBirth { get; }

        public Address Address { get; }

        public List<string> PhoneNumbers { get; } = new List<string>();

        public Contact(string name, DateTime dateOfBirth, Address address, string[] phoneNumbers)
            : this(Guid.NewGuid(), name, dateOfBirth, address, phoneNumbers)
        {
        }

        public Contact(Guid id, string name, DateTime dateOfBirth, Address address, string[] phoneNumbers)
            : base(id)
        {
            StringHelper.ThrowIfNullOrWhitespace(name, "Name can not be null or white space");
            ThrowIfNull(address, "Address can not be null");

            Name = name;
            DateOfBirth = dateOfBirth;
            Address = address;
            PhoneNumbers.AddRange(phoneNumbers);
        }

        private void ThrowIfNull(object value, string message)
        {
            if (value == null)
                throw new ArgumentNullException(message);
        }
    }
}
