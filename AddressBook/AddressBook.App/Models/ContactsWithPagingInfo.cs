using System.Collections.Generic;
using AddressBook.Domain.Models;

namespace AddressBook.App.Models
{
    public class ContactsWithPagingInfo
    {
        public IEnumerable<Contact> Contacts { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public int Total { get; set; }
    }
}
