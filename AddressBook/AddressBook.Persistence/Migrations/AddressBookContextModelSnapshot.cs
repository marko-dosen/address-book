﻿// <auto-generated />
using System;
using AddressBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AddressBook.Persistence.Migrations
{
    [DbContext(typeof(AddressBookContext))]
    partial class AddressBookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("AddressBook.Persistence.Models.DbContact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("AddressLine2")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("AddressLine3")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("VARCHAR(3)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("VARCHAR(15)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("Name", "AddressLine1", "AddressLine2", "AddressLine3", "City", "State", "Zip", "Country")
                        .IsUnique();

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("AddressBook.Persistence.Models.DbPhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<Guid>("ContactId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .HasColumnType("VARCHAR(30)");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("PhoneNumber");
                });

            modelBuilder.Entity("AddressBook.Persistence.Models.DbPhoneNumber", b =>
                {
                    b.HasOne("AddressBook.Persistence.Models.DbContact", "Contact")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
