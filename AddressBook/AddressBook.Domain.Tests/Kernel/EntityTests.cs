using System;
using System.Collections.Generic;
using System.Text;
using AddressBook.Domain.Kernel;
using NUnit.Framework;

namespace AddressBook.Domain.Tests.Kernel
{
    [TestFixture]
    public class EntityTest
    {
        private class EntityStub : Entity<int>
        {
            public string Property { get; }

            public EntityStub(int key, string property) : base(key)
            {
                Property = property;
            }
        }

        [Test]
        public void Should_throw_exception_when_creating_entity_with_default_id()
        {
            Assert.Throws<ArgumentException>(() => new EntityStub(0, "a"));
        }

        [Test]
        public void Should_be_equal_if_ids_are_same()
        {
            var a = new EntityStub(1, "a");
            var b = new EntityStub(1, "b");

            AssertAreEqual(a, b);
        }

        [Test]
        public void Should_not_be_equal_if_ids_are_different()
        {
            var a = new EntityStub(1, "a");
            var b = new EntityStub(2, "a");

            AssertAreNotEqual(a, b);
        }

        [Test]
        public void Should_be_equal_hash_if_ids_are_same()
        {
            var a = new EntityStub(1, "a");
            var b = new EntityStub(1, "b");

            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }

        [Test]
        public void Should_not_be_equal_has_if_ids_are_different()
        {
            var a = new EntityStub(1, "a");
            var b = new EntityStub(2, "a");

            Assert.AreNotEqual(a.GetHashCode(), b.GetHashCode());
        }

        [Test]
        public void Should_be_equal_when_comparing_nulls()
        {
            EntityStub a = null;
            EntityStub b = null;

            AssertAreEqual(a, b);
        }

        [Test]
        public void Should_not_be_equal_when_comparing_not_null_to_null()
        {
            var a = new EntityStub(1, "a");

            AssertAreNotEqual(a, null);
            AssertAreNotEqual(null, a);
        }

        private static void AssertAreEqual(EntityStub a, EntityStub b)
        {
            Assert.AreEqual(a, b);
            Assert.IsTrue(a == b);
            Assert.IsFalse(a != b);
        }
        private static void AssertAreNotEqual(EntityStub a, EntityStub b)
        {
            Assert.AreNotEqual(a, b);
            Assert.IsFalse(a == b);
            Assert.IsTrue(a != b);
        }
    }
}
