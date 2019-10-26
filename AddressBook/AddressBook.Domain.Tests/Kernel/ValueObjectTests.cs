using AddressBook.Domain.Kernel;
using NUnit.Framework;

namespace AddressBook.Domain.Tests.Kernel
{
    public class ValueObjectTest
    {
        private class ValueObjectStub : ValueObject<ValueObjectStub>
        {
            private int _integerField;
            private bool BooleanProperty { get; }
            public string StringProperty { get; }

            public ValueObjectStub(int integerField, string stringProperty, bool booleanProperty)
            {
                _integerField = integerField;
                BooleanProperty = booleanProperty;
                StringProperty = stringProperty;
            }
        }

        [Test]
        public void Should_be_equal_when_comparing_nulls()
        {
            ValueObjectStub a = null;
            ValueObjectStub b = null;

            AssertAreEqual(a, b);
        }

        [Test]
        public void Should_not_be_equal_when_comparing_not_null_to_null()
        {
            ValueObjectStub a = new ValueObjectStub(1, "a", true);

            AssertAreNotEqual(a, null);
            AssertAreNotEqual(null, a);
        }

        [Test]
        public void Should_be_equal_if_properties_and_fields_are_same()
        {
            var a = new ValueObjectStub(1, "a", true);
            var b = new ValueObjectStub(1, "a", true);

            AssertAreEqual(a, b);
        }

        [Test]
        public void Should_not_be_equal_if_they_have_at_least_one_private_field_different()
        {
            var a = new ValueObjectStub(1, "a", true);
            var b = new ValueObjectStub(2, "a", true);

            AssertAreNotEqual(a, b);
        }

        [Test]
        public void Should_not_be_equal_if_they_have_at_least_one_public_property_different()
        {
            var a = new ValueObjectStub(1, "a", true);
            var b = new ValueObjectStub(1, "b", true);

            AssertAreNotEqual(a, b);
        }

        [Test]
        public void Should_not_be_equal_if_they_have_at_least_one_private_property_different()
        {
            var a = new ValueObjectStub(1, "a", true);
            var b = new ValueObjectStub(1, "a", false);

            AssertAreNotEqual(a, b);
        }

        [Test]
        public void Should_be_equal_hash_if_properties_are_same()
        {
            var a = new ValueObjectStub(1, "a", true);
            var b = new ValueObjectStub(1, "a", true);

            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }

        [Test]
        public void Should_not_be_equal_has_if_properties_are_different()
        {
            var a = new ValueObjectStub(1, "a", true);
            var b = new ValueObjectStub(2, "a", true);

            Assert.AreNotEqual(a.GetHashCode(), b.GetHashCode());
        }

        [Test]
        public void Should_not_be_equal_if_they_have_different_types()
        {
            ValueObjectStub a = new ValueObjectStub(1, "a", true);

            Assert.AreNotEqual(a, "");
        }

        private static void AssertAreEqual(ValueObjectStub a, ValueObjectStub b)
        {
            Assert.AreEqual(a, b);
            Assert.IsTrue(a == b);
            Assert.IsFalse(a != b);
        }
        private static void AssertAreNotEqual(ValueObjectStub a, ValueObjectStub b)
        {
            Assert.AreNotEqual(a, b);
            Assert.IsFalse(a == b);
            Assert.IsTrue(a != b);
        }
    }
}
