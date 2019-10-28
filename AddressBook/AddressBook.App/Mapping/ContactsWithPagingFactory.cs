using System.Collections.Generic;
using System.Linq;
using AddressBook.Contracts.Models;
using Contact = AddressBook.Domain.Models.Contact;

namespace AddressBook.App.Mapping
{
    public static class ContactsWithPagingFactory
    {
        public static ContactsWithPagingInfo Create(this Models.ContactsWithPagingInfo contacts)
            => new ContactsWithPagingInfo
            {
                Pagination = CreatePagination(contacts),
                Contacts = CreateContacts(contacts?.Contacts)
            };

        private static PagingInfo CreatePagination(Models.ContactsWithPagingInfo contacts)
        {
            if (contacts == null)
                return null;
            return new PagingInfo
            {
                PageNumber = contacts.PageNumber,
                PageSize = contacts.PageSize,
                Total = contacts.Total
            };
        }

        private static ContactWithId[] CreateContacts(IEnumerable<Contact> contacts)
        {
            List<ContactWithId> result = new List<ContactWithId>();
            if (contacts != null && contacts.Any())
                foreach (Contact contact in contacts)
                {
                    result.Add(contact.CreateContactWithId());
                }

            return result.ToArray();
        }
    }
}
