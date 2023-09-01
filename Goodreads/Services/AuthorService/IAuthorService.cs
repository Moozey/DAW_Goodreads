using Goodreads.Models;
using Goodreads.Models.DTOs;
using System.IO;

namespace Goodreads.Services.AuthorService
{
    public interface IAuthorService
    {
        Task<Author> AddAuthor(AuthorDTO newAuthor);
        Task DeleteAuthorById(Guid id);
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<Author> GetAuthorById(Guid id);
        Task<Author> UpdateAuthorById(AuthorDTO updatedAuthor, Guid id);
        bool Save();
    }
}
