using AddressBook.App.Mapping;
using AddressBook.App.Services;
using AddressBook.Contracts.Models;

namespace AddressBook.App.UseCases
{
    public class UpdateContactUseCase
    {
        private readonly IContactRepository _repository;

        public UpdateContactUseCase(IContactRepository repository)
        {
            _repository = repository;
        }

        public ContactWithId Execute(ContactWithId contact)
            => _repository.UpdateContact(contact.CreateDomainContactWithId()).CreateContactWithId();

    }
}
