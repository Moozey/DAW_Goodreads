using Goodreads.Data;
using Goodreads.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Goodreads.Helpers.Seeders
{
    public class BookSeeder
    {
        public readonly GoodreadsContext _context;

        public BookSeeder(GoodreadsContext context)
        {
            _context = context;
        }

        public void SeedInitialBooks()
        {
            if (!_context.Books.Any())
            {
                //BOOK1
                // Retrieve an existing author from the database
                var existingAuthorBook1 = _context.Authors.FirstOrDefault(a => a.LastName == "Creanga");

                // If the author doesn't exist, create a new one
                if (existingAuthorBook1 == null)
                {
                    existingAuthorBook1 = new Author
                    {
                        FirstName = "Ion",
                        LastName = "creanga",
                        DateOfBirth = new DateTime(1837, 3, 1),
                        Nationality = "Romania"
                    };
                }
                var book1 = new Book
                {
                    BookTitle = "The Enigma Code",
                    BookDescription = "A thrilling espionage novel set during World War II, where a group of codebreakers races against time to decipher an unbreakable Nazi code.",
                    ReleaseDate = new DateTime(2020, 1, 15),
                    Author = existingAuthorBook1
                };

                //BOOK2
                // Retrieve an existing author from the database
                var existingAuthorBook2 = _context.Authors.FirstOrDefault(a => a.LastName == "Green");

                // If the author doesn't exist, create a new one
                if (existingAuthorBook2 == null)
                {
                    existingAuthorBook2 = new Author
                    {
                        FirstName = "David",
                        LastName = "Green",
                        DateOfBirth = new DateTime(1987, 6, 10),
                        Nationality = "Germany"
                    };
                }
                var book2 = new Book
                {
                    BookTitle = "The Science of Everything",
                    BookDescription = "A comprehensive exploration of the wonders of science, from the origins of the universe to the intricacies of the human body.",
                    ReleaseDate = new DateTime(2018, 2, 5),
                    Author = existingAuthorBook2
                };

                //BOOK3
                // Retrieve an existing author from the database
                var existingAuthorBook3 = _context.Authors.FirstOrDefault(a => a.LastName == "Eminescu");

                // If the author doesn't exist, create a new one
                if (existingAuthorBook3 == null)
                {
                    existingAuthorBook3 = new Author
                    {
                        FirstName = "Mihai",
                        LastName = "Eminescu",
                        DateOfBirth = new DateTime(1850, 1, 15),
                        Nationality = "Romania"
                    };
                }
                var book3 = new Book
                {
                    BookTitle = "Poems",
                    BookDescription = "A book containing all poems by ME",
                    ReleaseDate = new DateTime(1970, 7, 19),
                    Author = existingAuthorBook3
                };
                _context.Authors.Add(existingAuthorBook1); 
                _context.Authors.Add(existingAuthorBook2); 
                _context.Authors.Add(existingAuthorBook3); 
                _context.Books.Add(book1); 
                _context.Books.Add(book2); 
                _context.Books.Add(book3); 

                _context.SaveChanges();
            }
        }
    }
}
