using System;

namespace AddressBook.Domain.Helpers
{
    public static class StringHelper
    {
        public static void ThrowIfNullOrWhitespace(string value, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(message);
        }
    }
}
