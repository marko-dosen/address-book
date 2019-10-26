using System.ComponentModel.DataAnnotations;

namespace AddressBook.Contracts.Validation
{
    public class CountryCodeAttribute
        :RegularExpressionAttribute
    {
        private const string pattern = @"[A-Z]{3}";

        public CountryCodeAttribute() : base(pattern)
        {
            ErrorMessage = "Country code must be three letter, uppercase, ISO 3166-1 alpha-3 code.";
        }
    }
}
