using System;
using AddressBook.App.Services;
using AddressBook.App.Tests.Factories;
using AddressBook.App.UseCases;
using AddressBook.Domain.Models;
using Moq;
using NUnit.Framework;

namespace AddressBook.App.Tests.UseCases
{
    [TestFixture]
    public class GetContactUseCaseTests
    {

        [Test]
        public void Should_call_repository_get_contact_method_once()
        {
            var mockRepository = Mock.Of<IContactRepository>();

            var useCase = new GetContactUseCase(mockRepository);

            useCase.Execute(Guid.NewGuid());

            Mock.Get(mockRepository).Verify(x =>
                x.GetContact(It.IsAny<Guid>()), Times.Once);
        }
    }
}
