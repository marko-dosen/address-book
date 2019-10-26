using System;
using AddressBook.Domain.Models;

namespace AddressBook.App.Exceptions
{
    public class ContactAlreadyExistsException
        : Exception
    {
        public Contact Contact { get; }

        public ContactAlreadyExistsException()
            : base("Contact with same name and address already exists.")
        {

        }

        public ContactAlreadyExistsException(Contact contact)
            : this()
        {
            Contact = contact;
        }
    }
}
