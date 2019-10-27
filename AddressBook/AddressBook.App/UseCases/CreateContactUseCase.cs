using AddressBook.App.Mapping;
using AddressBook.App.Services;
using AddressBook.Contracts.Models;
using BoundaryContact = AddressBook.Contracts.Models.Contact;
using Contact = AddressBook.Domain.Models.Contact;

namespace AddressBook.App.UseCases
{
    public class CreateContactUseCase
    {
        private readonly IContactRepository _repository;

        public CreateContactUseCase(IContactRepository repository)
        {
            _repository = repository;
        }

        public ContactWithId Execute(BoundaryContact contact)
        {
            Contact domainContact = contact.CreateDomainContact();
            _repository.InsertContact(domainContact);
            return domainContact.CreateContactWithId();
        }
    }
}
