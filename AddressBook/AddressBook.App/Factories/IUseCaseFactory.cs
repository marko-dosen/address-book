using AddressBook.App.UseCases;

namespace AddressBook.App.Factories
{
    public interface IUseCaseFactory
    {
        CreateContactUseCase CreateContactUseCase();
    }
}
