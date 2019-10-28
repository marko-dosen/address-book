using AddressBook.App.Models;
using AddressBook.App.Services;
using AddressBook.App.UseCases;
using Moq;
using NUnit.Framework;

namespace AddressBook.App.Tests.UseCases
{
    [TestFixture]
    public class GetContactsUseCaseTests
    {
        [Test]
        public void Should_call_repository_get_contacts_method_once()
        {
            var mockRepository = Mock.Of<IContactRepository>();

            var useCase = new GetContactsUseCase(mockRepository);

            useCase.Execute(new PagingParameter());

            Mock.Get(mockRepository).Verify(x =>
                x.GetContacts(It.IsAny<PagingParameter>()), Times.Once);
        }
    }
}
