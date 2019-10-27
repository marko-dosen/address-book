using System;
using AddressBook.App.Services;

namespace AddressBook.App.UseCases
{
    public class DeleteContactUseCase
    {
        private readonly IContactRepository _repository;

        public DeleteContactUseCase(IContactRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid id)
            => _repository.DeleteContact(id);
    }
}
