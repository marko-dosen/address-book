using AddressBook.App.UseCases;

namespace AddressBook.App.Factories
{
    public interface IUseCaseFactory
    {
        CreateContactUseCase CreateContactUseCase();

        GetContactUseCase GetContactUseCase();

        GetContactsUseCase GetContactsUseCase();

        UpdateContactUseCase UpdateContactUseCase();

        DeleteContactUseCase DeleteContactUseCase();
    }
}
