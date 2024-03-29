﻿using System;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Contracts.Validation
{
    [AttributeUsage(
        AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class NotEmptyAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "The {0} field must not be empty";

        public NotEmptyAttribute() : base(DefaultErrorMessage)
        {
        }

        public override bool IsValid(object value)
        {
            if(value is null)
            {
                return true;
            }

            switch(value)
            {
                case Guid guid:
                    return guid != Guid.Empty;
                default:
                    return true;
            }
        }
    }
}
