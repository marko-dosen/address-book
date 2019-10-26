using System;
using System.Linq;
using AddressBook.App.Exceptions;
using AddressBook.App.Models;
using AddressBook.App.Services;
using AddressBook.Domain.Models;
using AddressBook.Persistence.Context;
using AddressBook.Persistence.Tests.Helpers;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
namespace AddressBook.Persistence.Tests
{
    [TestFixture]
    [Category("Integration")]
    public class ContactRepositoryTests
    {
        private IContactRepository _sut;
        private Contact _contact;

        [SetUp]
        public void RunBeforeEachTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AddressBookContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=AddressBook;Username=postgres;Password=admin");
            _sut = new ContactRepository(new AddressBookContext(optionsBuilder.Options));
            _contact = CreateContactWithUniqueName(Guid.NewGuid());
        }

        [Test]
        public void Should_be_able_to_create_repository()
        {

        }

        [Test]
        [Rollback]
        public void Should_be_able_to_insert_new_contact()
        {
            _sut.InsertContact(_contact);
        }

        [Test]
        [Rollback]
        public void Should_throw_exception_when_trying_to_insert_same_contacts()
        {
            _sut.InsertContact(_contact);
            Assert.Throws<ContactAlreadyExistsException>(() => _sut.InsertContact(_contact));
        }


        [Test]
        [Rollback]
        public void Should_be_able_to_return_contact_that_exist()
        {
            _sut.InsertContact(_contact);
            _sut.GetContact(_contact.Id);
        }

        [Test]
        [Rollback]
        public void Should_throw_exception_when_selecting_non_existing_contact()
        {
            Assert.Throws<ContactNotFoundException>(() => _sut.GetContact(Guid.NewGuid()));
        }

        [Test]
        [Rollback]
        public void Should_return_same_contact()
        {
            var id = Guid.NewGuid();
            Contact contact1 = CreateContactWithUniqueName(id);

            _sut.InsertContact(contact1);
            Contact contact2 = _sut.GetContact(id);

            contact2.Should().BeEquivalentTo(contact1);
        }


        [Test]
        [Rollback]
        public void Should_throw_exception_when_deleting_non_existing_contact()
        {
            Assert.Throws<ContactNotFoundException>(() => _sut.DeleteContact(Guid.NewGuid()));
        }

        [Test]
        [Rollback]
        public void Should_be_able_to_delete_existing_contact()
        {
            _sut.InsertContact(_contact);
            _sut.DeleteContact(_contact.Id);
        }

        [Test]
        [Rollback]
        public void Should_throw_exception_if_selecting_contact_that_was_deleted()
        {
            _sut.InsertContact(_contact);
            _sut.DeleteContact(_contact.Id);
            Assert.Throws<ContactNotFoundException>(() => _sut.GetContact(_contact.Id));
        }

        [Test]
        [Rollback]
        public void Should_throw_exception_when_updating_non_existing_contact()
        {
            Assert.Throws<ContactNotFoundException>(() => _sut.UpdateContact(_contact));
        }

        [Test]
        [Rollback]
        public void Should_be_able_to_update_existing_contact()
        {
            _sut.InsertContact(_contact);
            _sut.UpdateContact(_contact);
        }

        [Test]
        [Rollback]
        public void
            Should_throw_contact_already_exist_exception_when_trying_to_update_different_contact_to_existing_contact()
        {
            Guid id = Guid.NewGuid();
            string name = Guid.NewGuid().ToString();
            Guid id2 = Guid.NewGuid();
            string name2 = Guid.NewGuid().ToString();

            var contact1 = new Contact(id, name, DateTime.Today, CreateAddress(), CreatePhoneNumbers());
            _sut.InsertContact(contact1);

            var contact2 = new Contact(id2, name2, DateTime.Today, CreateAddress(), CreatePhoneNumbers());
            _sut.InsertContact(contact2);

            var contactUpdate = new Contact(id2, name, DateTime.UtcNow, CreateAddress(), CreatePhoneNumbers());

            Assert.Throws<ContactAlreadyExistsException>(() => _sut.UpdateContact(contactUpdate));
        }

        [Test]
        [Rollback]
        public void Should_update_all_properties_when_updating_existing_contact()
        {
            Guid id = Guid.NewGuid();
            string name = Guid.NewGuid().ToString();

            var contact1 = new Contact(id, name, DateTime.Today, CreateAddress(), CreatePhoneNumbers());
            _sut.InsertContact(contact1);


            var contact2 = new Contact(id, Guid.NewGuid().ToString(), new DateTime(1994, 04, 29),
                new Address("Somewhere", "", "Apt.3", "Shenzhen", "Guangdong", "69043", "CHN"), new[] { "113321321" });

            _sut.UpdateContact(contact2);
            Contact contactFromDb = _sut.GetContact(id);
            contactFromDb.Should().BeEquivalentTo(contact2);
        }

        [Test]
        [Rollback]
        public void Should_be_able_to_get_contacts_for_any_pagination()
        {
            Random random = new Random();
            PagingParameter paging = new PagingParameter
            {
                PageSize = random.Next(100),
                PageNumber = random.Next(100)
            };

            _sut.GetContacts(paging);
        }

        [Test]
        [Rollback]
        public void Should_get_correct_number_of_contacts_with_pagination()
        {
            PagingParameter paging = new PagingParameter
            {
                PageSize = 2,
                PageNumber = 1
            };

            for (int i = 0; i < 3; i++)
                _sut.InsertContact(CreateContactWithUniqueName(Guid.NewGuid()));

            Assert.AreEqual(2, _sut.GetContacts(paging).Contacts.Count());
        }

        [Test]
        [Rollback]
        public void Should_set_total_property_after_getting_contacts()
        {
            for (int i = 0; i < 1; i++)
                _sut.InsertContact(CreateContactWithUniqueName(Guid.NewGuid()));

            Assert.Greater(_sut.GetContacts(new PagingParameter()).Total, 0);
        }

        private static Contact CreateContactWithUniqueName(Guid id)
            => new Contact(id, Guid.NewGuid().ToString(), DateTime.Today, CreateAddress(), CreatePhoneNumbers());

        private static Address CreateAddress()
            => new Address("Sample of Address line 1", "Sample of Address line 2", "Sample of Address line 3",
                "Podgorica", "Montenegro", "81000", "MNE");

        private static string[] CreatePhoneNumbers()
            => new[] { "123123", "321478213" };
    }
}
