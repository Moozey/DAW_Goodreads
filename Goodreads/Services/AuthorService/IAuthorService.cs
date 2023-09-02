using Goodreads.Models;
using Goodreads.Models.DTOs;
using System.IO;

namespace Goodreads.Services.AuthorService
{
    public interface IAuthorService
    {
        Task<Author> AddAuthor(AuthorDTO newAuthor);
        Task<IEnumerable<Author>> GetAllAuthors();
        Author getAuthorById2(Guid id);
        Task DeleteAuthor(Author authorToDelete);
        Task<Author> UpdateAuthorById(AuthorDTO updatedAuthor, Guid id);
        bool Save();
    }
}
