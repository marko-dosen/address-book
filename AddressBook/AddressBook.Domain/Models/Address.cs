using System;

namespace AddressBook.Domain.Models
{
    public class Address
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
            ThrowIfNullOrWhitespace(addressLine1, "Address Line 1 can not be null or white space");
            ThrowIfNullOrWhitespace(city, "City can not be null or white space");
            ThrowIfNullOrWhitespace(state, "State can not be null or white space");
            ThrowIfNullOrWhitespace(zip, "Zip can not be null or white space");
            ThrowIfNullOrWhitespace(country, "Country can not be null or white space");

            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            AddressLine3 = addressLine3;
            City = city;
            State = state;
            Zip = zip;
            Country = country;
        }

        public override bool Equals(object obj)
        {
            var address = obj as Address;
            if (address == null)
                return false;
            return AddressLine1 == address.AddressLine1
                   && AddressLine2 == address.AddressLine2
                   && AddressLine3 == address.AddressLine3
                   && City == address.City
                   && State == address.State
                   && Zip == address.Zip
                   && Country == address.Country;
        }

        public override int GetHashCode()
            => new
            {
                AddressLine1,
                AddressLine2,
                AddressLine3,
                City,
                State,
                Zip,
                Country
            }.GetHashCode();

        public static bool operator ==(Address x, Address y)
            => Equals(x, y);

        public static bool operator !=(Address x, Address y)
            => !Equals(x, y);

        private void ThrowIfNullOrWhitespace(string value, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(message);
        }
    }
}
