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

        public GetContactUseCase GetContactUseCase()
            => new GetContactUseCase(_repository);

        public GetContactsUseCase GetContactsUseCase()
            => new GetContactsUseCase(_repository);

        public UpdateContactUseCase UpdateContactUseCase()
            => new UpdateContactUseCase(_repository);

        public DeleteContactUseCase DeleteContactUseCase()
            => new DeleteContactUseCase(_repository);
    }
}
