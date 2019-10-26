using System;
using System.Transactions;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace AddressBook.Persistence.Tests.Helpers
{
    public class RollbackAttribute : Attribute, ITestAction
    {
        private TransactionScope _transaction;

        public void BeforeTest(ITest testDetails)
        {
            _transaction = new TransactionScope();
        }

        public void AfterTest(ITest testDetails)
        {
            _transaction.Dispose();
        }

        public ActionTargets Targets => ActionTargets.Test;
    }
}