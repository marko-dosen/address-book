namespace AddressBook.Contracts.Models
{
    /// <summary>
    /// Contact model with unique identifier
    /// extended with pagination info.
    /// </summary>
    public class ContactsWithPagingInfo
    {
        public ContactWithId[] Contacts { get; set; }

        public PagingInfo Pagination { get; set; }
        
    }
}
