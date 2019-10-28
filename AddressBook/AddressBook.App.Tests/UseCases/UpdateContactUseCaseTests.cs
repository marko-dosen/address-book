using AddressBook.App.Mapping;
using AddressBook.App.Services;
using AddressBook.App.UseCases;
using AddressBook.Contracts.Models;
using Moq;
using NUnit.Framework;
using Contact = AddressBook.Domain.Models.Contact;
using ContactFactory = AddressBook.App.Tests.Factories.ContactFactory;

namespace AddressBook.App.Tests.UseCases
{
    [TestFixture]
    public class UpdateContactUseCaseTests
    {
        [Test]
        public void Should_call_repository_update_method_once()
        {
            var mockRepository = Mock.Of<IContactRepository>();

            var useCase = new UpdateContactUseCase(mockRepository);

            useCase.Execute(ContactFactory.CreateContactWithId());

            Mock.Get(mockRepository).Verify(x =>
                x.UpdateContact(It.IsAny<Contact>()), Times.Once);
        }
    }
}
