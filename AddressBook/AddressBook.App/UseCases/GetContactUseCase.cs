using System;
using AddressBook.App.Mapping;
using AddressBook.App.Services;
using AddressBook.Contracts.Models;

namespace AddressBook.App.UseCases
{
    public class GetContactUseCase
    {
        private readonly IContactRepository _repository;

        public GetContactUseCase(IContactRepository repository)
        {
            _repository = repository;
        }

        public ContactWithId Execute(Guid id)
            => _repository.GetContact(id).CreateContactWithId();
    }
}
