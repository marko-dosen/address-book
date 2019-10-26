using AddressBook.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Persistence.Context
{
    public class AddressBookContext
        : DbContext
    {
        public DbSet<DbContact> Contacts { get; set; }
        public DbSet<DbPhoneNumber> PhoneNumbers { get; set; }

        public AddressBookContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MapContacts(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void MapContacts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbContact>()
                .HasIndex(c => c.Reference).IsUnique();

            modelBuilder.Entity<DbContact>()
                .HasIndex(c => new
                {
                    c.Name,
                    c.AddressLine1,
                    c.AddressLine2,
                    c.AddressLine3,
                    c.City,
                    c.State,
                    c.Zip,
                    c.Country
                }).IsUnique();


            modelBuilder.Entity<DbContact>()
                .Property(p => p.Reference)
                .IsRequired();
            modelBuilder.Entity<DbContact>()
                .Property(p => p.AddressLine1)
                .IsRequired();
            modelBuilder.Entity<DbContact>()
                .Property(p => p.City)
                .IsRequired();
            modelBuilder.Entity<DbContact>()
                .Property(p => p.Country)
                .IsRequired();
            modelBuilder.Entity<DbContact>()
                .Property(p => p.State)
                .IsRequired();
            modelBuilder.Entity<DbContact>()
                .Property(p => p.Zip)
                .IsRequired();
            modelBuilder.Entity<DbContact>()
                .Property(p => p.Name)
                .IsRequired();
            modelBuilder.Entity<DbContact>()
                .Property(p => p.DateOfBirth)
                .IsRequired();
        }
    }
}
