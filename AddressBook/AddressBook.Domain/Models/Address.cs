using AddressBook.Domain.Helpers;
using AddressBook.Domain.Kernel;

namespace AddressBook.Domain.Models
{
    public class Address
        : ValueObject<Address>
    {
        public string AddressLine1 { get; }

        public string AddressLine2 { get; }

        public string AddressLine3 { get; }

        public string City { get; }

        public string State { get; }

        public string Zip { get; }

        public string Country { get; }

        public Address(string addressLine1, string addressLine2, string addressLine3, string city, string state, string zip, string country)
        {

            StringHelper.ThrowIfNullOrWhitespace(addressLine1, "Address Line 1 can not be null or white space");
            StringHelper.ThrowIfNullOrWhitespace(city, "City can not be null or white space");
            StringHelper.ThrowIfNullOrWhitespace(state, "State can not be null or white space");
            StringHelper.ThrowIfNullOrWhitespace(zip, "Zip can not be null or white space");
            StringHelper.ThrowIfNullOrWhitespace(country, "Country can not be null or white space");

            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2 ?? string.Empty;
            AddressLine3 = addressLine3 ?? string.Empty;
            City = city;
            State = state;
            Zip = zip;
            Country = country;
        }
    }
}
