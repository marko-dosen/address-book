using System;
using System.Collections.Generic;
using AddressBook.Domain.Helpers;

namespace AddressBook.Domain.Models
{
    public class Contact
    {
        public  Guid Id { get; }
        public string Name { get; }

        public DateTime DateOfBirth { get; }

        public Address Address { get; }

        public List<string> PhoneNumbers { get; }

        private Contact(Guid id)
        {
            Id = id;
            PhoneNumbers = new List<string>();
        }

        public Contact(string name, DateTime dateOfBirth, Address address, string[] phoneNumbers)
            : this(Guid.NewGuid())
        {
            StringHelper.ThrowIfNullOrWhitespace(name, "Name can not be null or white space");
            ThrowIfNull(address, "Address can not be null");

            Name = name;
            DateOfBirth = dateOfBirth;
            Address = address;
            PhoneNumbers.AddRange(phoneNumbers);
        }

        public override bool Equals(object obj)
        {
            var contact = obj as Contact;
            if (contact == null)
                return false;
            return contact.Name == Name
                   && contact.Address == Address;
        }

        public override int GetHashCode()
            => new { Name, Address }.GetHashCode();

        public static bool operator ==(Contact x, Contact y)
            => Equals(x, y);

        public static bool operator !=(Contact x, Contact y)
            => !Equals(x, y);

        private void ThrowIfNull(object value, string message)
        {
            if (value == null)
                throw new ArgumentNullException(message);
        }
    }
}
