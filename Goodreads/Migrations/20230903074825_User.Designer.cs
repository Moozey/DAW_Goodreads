﻿// <auto-generated />
using System;
using Goodreads.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Goodreads.Migrations
{
    [DbContext(typeof(GoodreadsContext))]
    [Migration("20230903074825_User")]
    partial class User
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Goodreads.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Goodreads.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BookDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Goodreads.Models.BookGenre", b =>
                {
                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BookId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("BookGenres");
                });

            modelBuilder.Entity("Goodreads.Models.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Goodreads.Models.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<string>("ReviewDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Goodreads.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Goodreads.Models.UserPrivateDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ColorPreference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreferredBook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ReceiveNotifications")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserPrivateDetails");
                });

            modelBuilder.Entity("Goodreads.Models.Book", b =>
                {
                    b.HasOne("Goodreads.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Goodreads.Models.BookGenre", b =>
                {
                    b.HasOne("Goodreads.Models.Book", "Book")
                        .WithMany("BookGenre")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Goodreads.Models.Genre", "Genre")
                        .WithMany("BookGenre")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Goodreads.Models.User", b =>
                {
                    b.HasOne("Goodreads.Models.Author", null)
                        .WithMany("Users")
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("Goodreads.Models.UserPrivateDetails", b =>
                {
                    b.HasOne("Goodreads.Models.User", "User")
                        .WithOne("UserPrivateDetails")
                        .HasForeignKey("Goodreads.Models.UserPrivateDetails", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Goodreads.Models.Author", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Goodreads.Models.Book", b =>
                {
                    b.Navigation("BookGenre");
                });

            modelBuilder.Entity("Goodreads.Models.Genre", b =>
                {
                    b.Navigation("BookGenre");
                });

            modelBuilder.Entity("Goodreads.Models.User", b =>
                {
                    b.Navigation("UserPrivateDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
