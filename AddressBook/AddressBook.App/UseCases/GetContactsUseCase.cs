using AddressBook.App.Mapping;
using AddressBook.App.Models;
using AddressBook.App.Services;
using ContactsWithPagingInfo = AddressBook.Contracts.Models.ContactsWithPagingInfo;

namespace AddressBook.App.UseCases
{
    public class GetContactsUseCase
    {
        private readonly IContactRepository _repository;

        public GetContactsUseCase(IContactRepository repository)
        {
            _repository = repository;
        }

        public ContactsWithPagingInfo Execute(PagingParameter pagination)
            => _repository.GetContacts(pagination).Create();
    }
}
