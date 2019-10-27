using AddressBook.App.Services;
using AddressBook.App.UseCases;
using AddressBook.Domain.Models;
using Moq;
using NUnit.Framework;
using ContactFactory = AddressBook.App.Tests.Factories.ContactFactory;

namespace AddressBook.App.Tests.UseCases
{
    [TestFixture]
    public class CreateContactUseCaseTests
    {

        [Test]
        public void Should_call_repository_insert_method_once()
        {
            var mockRepository = Mock.Of<IContactRepository>();

            var useCase = new CreateContactUseCase(mockRepository);

            useCase.Execute(ContactFactory.Create());

            Mock.Get(mockRepository).Verify(x =>
                x.InsertContact(It.IsAny<Contact>()), Times.Once);
        }
    }
}
