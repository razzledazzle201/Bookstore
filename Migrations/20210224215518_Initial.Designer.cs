﻿// <auto-generated />
using Bookstore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bookstore.Migrations
{
    [DbContext(typeof(BookstoreDbContext))]
    [Migration("20210309165638_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12");

            modelBuilder.Entity("Bookstore.Models.BookModel", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BookAuthorFirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BookAuthorLastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BookAuthorMiddleName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BookCategory")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BookClassification")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BookISBN")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("BookPages")
                        .HasColumnType("INTEGER");

                    b.Property<double>("BookPrice")
                        .HasColumnType("REAL");

                    b.Property<string>("BookPublisher")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BookTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BookId");

                    b.ToTable("BookModels");
                });
#pragma warning restore 612, 618
        }
    }
}
