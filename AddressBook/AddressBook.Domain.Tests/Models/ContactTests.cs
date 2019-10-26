using System;
using AddressBook.Domain.Models;
using NUnit.Framework;

namespace AddressBook.Domain.Tests.Models
{
    [TestFixture]
    public class ContactTests
    {
        private readonly string _name = "Marko Dosen";
        private readonly DateTime _dateOfBirth = new DateTime(1993, 04, 29);
        private readonly Address _address = CreateAddress();
        private readonly string[] _phoneNumbers = CreatePhoneNumbers();


        private Contact _sut;

        [SetUp]
        public void RunBeforeEachTest()
        {
            _sut = new Contact(_name, _dateOfBirth, _address, _phoneNumbers);
        }

        [Test]
        public void Should_be_able_to_create_contact()
        {

        }

        [Test]
        public void Should_have_not_empty_id()
        {
            Assert.AreNotEqual(Guid.Empty, _sut.Id);
        }

        [Test]
        public void Should_have_correct_name()
        {
            Assert.AreEqual(_name, _sut.Name);
        }

        [Test]
        public void Should_have_correct_date_of_birth()
        {
            Assert.AreEqual(_dateOfBirth, _sut.DateOfBirth);
        }

        [Test]
        public void Should_have_correct_address()
        {
            Assert.AreEqual(_address, _sut.Address);
        }

        [Test]
        public void Should_have_correct_phoneNumbers()
        {
            Assert.AreEqual(_phoneNumbers, _sut.PhoneNumbers);
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Should_throw_argument_null_exception_if_name_is_null_or_white_space(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Contact(name, DateTime.Now, _address, CreatePhoneNumbers()));
        }

        [Test]
        public void Should_throw_argument_null_exception_if_address_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => new Contact("Marko", DateTime.Now, null, CreatePhoneNumbers()));
        }

        [Test]
        public void Should_return_false_when_comparing_null_and_contact()
        {
            var contact = new Contact("Marko", DateTime.Now, _address, CreatePhoneNumbers());

            Assert.IsNotNull(contact);
            Assert.False(contact.Equals(null));
        }

        [Test]
        public void Should_return_true_when_comparing_contacts_with_same_id()
        {
            var id = Guid.NewGuid();
            var contact1 = new Contact(id, "Marko Markovic", DateTime.Now, _address, CreatePhoneNumbers());
            var contact2 = new Contact(id, "Pero Peric", DateTime.UtcNow, _address, new[] { "123", "321" });

            Assert.True(contact1.Equals(contact2));
            Assert.True(contact1 == contact2);
        }

        [Test]
        public void Should_return_false_when_comparing_contacts_with_different_names()
        {
            var contact1 = new Contact("Marko Markovic", DateTime.Now, _address, CreatePhoneNumbers());
            var contact2 = new Contact("Pero Peric", DateTime.UtcNow, _address, new[] { "123", "321" });

            Assert.False(contact1.Equals(contact2));
            Assert.True(contact1 != contact2);
        }

        [Test]
        public void Should_return_false_when_comparing_contacts_with_different_addresses()
        {
            var contact1 = new Contact("Marko Markovic", DateTime.Now, _address, CreatePhoneNumbers());
            var contact2 = new Contact("Marko Markovic", DateTime.Now, new Address("a", "b", "c", "d", "e", "f", "g"), CreatePhoneNumbers());

            Assert.False(contact1.Equals(contact2));
            Assert.True(contact1 != contact2);
        }

        private static Address CreateAddress()
            => new Address("Sample of Address line 1", "Sample of Address line 2", "Sample of Address line 3",
                "Podgorica", "Montenegro", "81000", "Datsunland");

        private static string[] CreatePhoneNumbers()
            => new[] { "123123", "321478213" };

    }
}
