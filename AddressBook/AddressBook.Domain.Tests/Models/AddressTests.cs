using System;
using AddressBook.Domain.Models;
using NUnit.Framework;
namespace AddressBook.Domain.Tests.Models
{
    [TestFixture]
    public class AddressTests
    {
        private readonly string _addressLine1 = "Sample of Address line 1";
        private readonly string _addressLine2 = "Sample of Address line 2";
        private readonly string _addressLine3 = "Sample of Address line 3";
        private readonly string _city = "Podgorica";
        private readonly string _state = "Montenegro";
        private readonly string _zip = "81000";
        private readonly string _country = "Zombieland";

        private Address _sut;

        [SetUp]
        public void RunBeforeEachTest()
        {
            _sut = new Address(_addressLine1, _addressLine2, _addressLine3,
                _city, _state, _zip, _country);
        }

        [Test]
        public void Should_be_able_to_create_address()
        {
        }

        [Test]
        public void Should_have_correct_address_line_1()
        {
            Assert.AreEqual(_addressLine1, _sut.AddressLine1);
        }

        [Test]
        public void Should_have_correct_address_line_2()
        {
            Assert.AreEqual(_addressLine2, _sut.AddressLine2);
        }

        [Test]
        public void Should_have_correct_address_line_3()
        {
            Assert.AreEqual(_addressLine3, _sut.AddressLine3);
        }

        [Test]
        public void Should_have_correct_city()
        {
            Assert.AreEqual(_city, _sut.City);
        }

        [Test]
        public void Should_have_correct_state()
        {
            Assert.AreEqual(_state, _sut.State);
        }

        [Test]
        public void Should_have_correct_zip()
        {
            Assert.AreEqual(_zip, _sut.Zip);
        }

        [Test]
        public void Should_have_correct_country()
        {
            Assert.AreEqual(_country, _sut.Country);
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Should_throw_argument_null_exception_if_address_line_1_is_null_or_white_space(string addressLine1)
        {
            Assert.Throws<ArgumentNullException>(() => { new Address(addressLine1, "b", "c", "d", "e", "f", "a"); });
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Should_throw_argument_null_exception_if_city_is_null_or_white_space(string city)
        {
            Assert.Throws<ArgumentNullException>(() => new Address("a", "s", "d", city, "c", "d", "e"));
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Should_throw_argument_null_exception_if_state_is_null_or_white_space(string state)
        {
            Assert.Throws<ArgumentNullException>(() => new Address("a", "s", "d", "b", state, "d", "e"));
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Should_throw_argument_null_exception_if_zip_is_null_or_white_space(string zip)
        {
            Assert.Throws<ArgumentNullException>(() => new Address("a", "s", "d", "b", "c", zip, "e"));
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Should_throw_argument_null_exception_if_country_is_null_or_white_space(string country)
        {
            Assert.Throws<ArgumentNullException>(() => new Address("a", "s", "d", "b", "c", "d", country));
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Should_not_throw_exception_if_address_line_2_is_null_or_white_space(string addressLine2)
        {
            var address = new Address("a", addressLine2, "c", "d", "e", "f", "g");
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Should_not_throw_exception_if_address_line_3_is_null_or_white_space(string addressLine3)
        {
            var address = new Address("a", "b", addressLine3, "d", "e", "f", "g");
        }

        [Test]
        public void Should_return_false_when_comparing_null_and_address()
        {
            var address = new Address("a", "s", "d", "f", "c", "d", "e");

            Assert.IsNotNull(address);
            Assert.False(address.Equals(null));
        }

        [Test]
        public void Should_return_true_when_comparing_two_equal_addresses()
        {
            var address1 = new Address("a", "s", "d", "f", "c", "d", "e");
            var address2 = new Address("a", "s", "d", "f", "c", "d", "e");

            Assert.True(address1.Equals(address2));
            Assert.True(address1 == address2);
        }

        [Test]
        public void Should_return_false_when_comparing_two_different_addresses()
        {
            var address1 = new Address("a", "s", "d", "f", "c", "d", "e");
            var address2 = new Address("e", "g", "z", "a", "q", "w", "r");

            Assert.False(address1.Equals(address2));
            Assert.True(address1 != address2);
        }
    }

}
