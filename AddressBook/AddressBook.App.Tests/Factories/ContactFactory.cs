using System;
using AddressBook.Contracts.Models;

namespace AddressBook.App.Tests.Factories
{
    public static class ContactFactory
    {
        public static Contact Create()
            => new Contact
            {
                Address = CreateAddress(),
                Name = "Marko Markovic",
                PhoneNumbers = CreatePhoneNumbers(),
                DateOfBirth = DateTime.Now
            };

        private static Address CreateAddress()
            => new Address
            {
                AddressLine1 = "Sample of Address line 1",
                AddressLine2 = "Sample of Address line 2",
                AddressLine3 = "Sample of Address line 3",
                State = "Montenegro",
                City = "Podgorica",
                Country = "Datsunland",
                Zip = "81000"
            };

        private static string[] CreatePhoneNumbers()
            => new[] { "123123", "321478213" };
    }
}
