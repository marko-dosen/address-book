using System;
using System.Collections.Generic;
using AddressBook.App.Models;
using AddressBook.Domain.Models;

namespace AddressBook.App.Services
{
    public interface IContactRepository
    {
        Contact GetContact(Guid id);

        ContactsWithPagingInfo GetContacts(PagingParameter pagination);

        void InsertContact(Contact contact);

        void DeleteContact(Guid id);

        Contact UpdateContact(Contact contact);
    }
}
