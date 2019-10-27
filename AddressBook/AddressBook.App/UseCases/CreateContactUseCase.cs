using AddressBook.App.Mapping;
using AddressBook.App.Services;
using AddressBook.Domain.Models;
using BoundaryContact = AddressBook.Contracts.Models.Contact;

namespace AddressBook.App.UseCases
{
    public class CreateContactUseCase
    {
        private readonly IContactRepository _repository;
        
        public CreateContactUseCase(IContactRepository repository)
        {
            _repository = repository;
        }

        public Contact Execute(BoundaryContact contact)
        {
            Contact domainContact = contact.CreateDomainContact();
            _repository.InsertContact(domainContact);
            return domainContact;
        }
    }
}
