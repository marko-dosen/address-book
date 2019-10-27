using AddressBook.App.Services;
using AddressBook.App.UseCases;

namespace AddressBook.App.Factories
{
    public class UseCaseFactory
        : IUseCaseFactory
    {
        private readonly IContactRepository _repository;

        public UseCaseFactory(IContactRepository repository)
        {
            _repository = repository;
        }

        public CreateContactUseCase CreateContactUseCase()
            => new CreateContactUseCase(_repository);
    }
}
