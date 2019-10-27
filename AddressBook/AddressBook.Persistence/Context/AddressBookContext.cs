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
                .HasKey(c => c.Id);

            modelBuilder.Entity<DbContact>()
                .HasIndex(c => c.Id).IsUnique();

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
                .Property(p => p.Id)
                .IsRequired();
            modelBuilder.Entity<DbContact>()
                .Property(p => p.AddressLine1)
                .IsRequired();
            modelBuilder.Entity<DbContact>()
                .Property(p => p.AddressLine2)
                .IsRequired();
            modelBuilder.Entity<DbContact>()
                .Property(p => p.AddressLine3)
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
