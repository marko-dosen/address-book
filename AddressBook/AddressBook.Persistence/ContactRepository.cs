using System;
using System.Collections.Generic;
using System.Linq;
using AddressBook.App.Exceptions;
using AddressBook.App.Models;
using AddressBook.App.Services;
using AddressBook.Domain.Models;
using AddressBook.Persistence.Context;
using AddressBook.Persistence.Mapping;
using AddressBook.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Persistence
{
    public class ContactRepository
        : IContactRepository
    {
        private readonly AddressBookContext _context;
        private const string UniqueConstraintException = "23505";

        public ContactRepository(AddressBookContext context)
        {
            _context = context;
        }

        public Contact GetContact(Guid id)
        {
            DbContact contact = _context.Contacts
                .Include(c => c.PhoneNumbers).FirstOrDefault(c => c.Id == id);
            if (contact == default)
                throw new ContactNotFoundException();
            return contact.CreateDomainContact();
        }

        public ContactsWithPagingInfo GetContacts(PagingParameter pagination)
        {
            DbContact[] contacts = _context.Contacts.Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize).Include(c => c.PhoneNumbers).ToArray();

            int count = _context.Contacts.Count();
            List<Contact> result = new List<Contact>();
            foreach (DbContact contact in contacts)
            {
                result.Add(contact.CreateDomainContact());
            }
            return new ContactsWithPagingInfo
            {
                Contacts = result,
                PageSize = pagination.PageSize,
                PageNumber = pagination.PageNumber,
                Total = count
            };
        }

        public void InsertContact(Contact contact)
        {
            DbContact dbContact = _context.Contacts
                .FirstOrDefault(c => c.Name == contact.Name
                                     && c.AddressLine1 == contact.Address.AddressLine1
                                     && c.AddressLine2 == contact.Address.AddressLine2
                                     && c.AddressLine3 == contact.Address.AddressLine3
                                     && c.City == contact.Address.City
                                     && c.State == contact.Address.State
                                     && c.Zip == contact.Address.Zip
                                     && c.Country == contact.Address.Country);
            if (dbContact != default)
                throw new ContactAlreadyExistsException(dbContact.CreateDomainContact());

            _context.Contacts.Add(contact.MapToDbContact());
            _context.SaveChanges();
        }

        public void DeleteContact(Guid id)
        {
            DbContact contact = _context.Contacts
                .FirstOrDefault(c => c.Id == id);
            if (contact == default)
                throw new ContactNotFoundException();

            _context.Contacts.Remove(contact);
            _context.SaveChanges();
        }

        public Contact UpdateContact(Contact contact)
        {
            DbContact dbContact = _context.Contacts
                .Include(c => c.PhoneNumbers)
                .FirstOrDefault(c => c.Id == contact.Id);
            if (dbContact == default)
                throw new ContactNotFoundException();

            UpdateContactProperties(dbContact, contact);
            _context.Contacts.Update(dbContact);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
                when (ex.InnerException is Npgsql.PostgresException sqlException
                      && sqlException.SqlState == UniqueConstraintException)
            {
                throw new ContactAlreadyExistsException();
            }

            return dbContact.CreateDomainContact();
        }

        private void UpdateContactProperties(DbContact dbContact, Contact contact)
        {
            dbContact.AddressLine1 = contact.Address?.AddressLine1;
            dbContact.AddressLine2 = contact.Address?.AddressLine2;
            dbContact.AddressLine3 = contact.Address?.AddressLine3;
            dbContact.City = contact.Address?.City;
            dbContact.State = contact.Address?.State;
            dbContact.Country = contact.Address?.Country;
            dbContact.Zip = contact.Address?.Zip;
            dbContact.Name = contact.Name;
            dbContact.DateOfBirth = contact.DateOfBirth;
            dbContact.PhoneNumbers = MapPhoneNumbers(contact.PhoneNumbers);
        }

        private ICollection<DbPhoneNumber> MapPhoneNumbers(List<string> contactPhoneNumbers)
            => contactPhoneNumbers.Select(p => new DbPhoneNumber { Value = p }).ToList();
    }
}
