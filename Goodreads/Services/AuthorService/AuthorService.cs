using Goodreads.Data.UnitOfWork;
using Goodreads.Models;
using Goodreads.Models.DTOs;
using Goodreads.Repositories.AuthorRepository;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Goodreads.Services.AuthorService
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> AddAuthor(AuthorDTO newAuthor)
        {
            var author = new Author
            {
                FirstName = newAuthor.FirstName,
                LastName = newAuthor.LastName
            };
            await _authorRepository.CreateAsync(author);
            return author;
        }


        public async Task DeleteAuthor(Author authorToDelete)
        {
            _authorRepository.Delete(authorToDelete);

        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _authorRepository.GetAllAuthors();
        }

        
        public Author getAuthorById2(Guid id)
        {
            return _authorRepository.GetById2(id);
        }

        public async Task<Author> UpdateAuthorById(AuthorDTO updatedAuthor, Guid id)
        {
            var author =  _authorRepository.GetById2(id);
            if (author == null)
            {
                throw new ArgumentException("Author not found");
            }

            author.FirstName = updatedAuthor.FirstName;
            author.LastName = updatedAuthor.LastName;

            _authorRepository.Update(author);
            _authorRepository.SaveAsync();

            return author;
        }
        public bool Save()
        {
            return _authorRepository.Save();
        }

    }
}
