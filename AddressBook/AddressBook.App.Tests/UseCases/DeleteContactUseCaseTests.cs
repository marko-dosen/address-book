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
    public class DeleteContactUseCaseTests
    {
        [Test]
        public void Should_call_repository_delete_method_once()
        {
            var mockRepository = Mock.Of<IContactRepository>();

            var useCase = new DeleteContactUseCase(mockRepository);

            useCase.Execute(Guid.NewGuid());

            Mock.Get(mockRepository).Verify(x =>
                x.DeleteContact(It.IsAny<Guid>()), Times.Once);
        }
    }
}
