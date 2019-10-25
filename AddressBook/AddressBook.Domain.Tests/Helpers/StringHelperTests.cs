using System;
using AddressBook.Domain.Helpers;
using NUnit.Framework;

namespace AddressBook.Domain.Tests.Helpers
{
    [TestFixture]
    public class StringHelperTests
    {

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Should_throw_null_argument_exception_for_null_or_white_space_value(string value)
        {
            Assert.Throws<ArgumentNullException>(() => StringHelper.ThrowIfNullOrWhitespace(value, "Any message"));
        }

        [Test]
        public void Should_not_throw_exception_for_string_value_that_is_not_null_or_white_space()
        {
            StringHelper.ThrowIfNullOrWhitespace("Just a random string.", "With a random message");
        }
    }
}
