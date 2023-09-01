using Goodreads.Models;
using Goodreads.Models.DTOs;
using Goodreads.Repositories.AuthorRepository;
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

        public async Task DeleteAuthorById(Guid id)
        {
            var authorToDelete = await GetAuthorById(id);
            if (authorToDelete != null)
            {
                _authorRepository.Delete(authorToDelete);
                await _authorRepository.SaveAsync();
            }
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _authorRepository.GetAllAuthors();
        }

        public async Task<Author> GetAuthorById(Guid id)
        {
            return await _authorRepository.GetById(id);
        }

        public async Task<Author> UpdateAuthorById(AuthorDTO updatedAuthor, Guid id)
        {
            var author = await _authorRepository.GetById(id);
            if (author == null)
            {
                throw new ArgumentException("Author not found");
            }

            author.FirstName = updatedAuthor.FirstName;
            author.LastName = updatedAuthor.LastName;

            _authorRepository.Update(author);
            await _authorRepository.SaveAsync();

            return author;
        }
        public bool Save()
        {
            return _authorRepository.SaveAsync().Result;
        }

    }
}
