﻿using Goodreads.Models;
using Goodreads.Repositories.GenericRepository;
using System.IO;

namespace Goodreads.Repositories.AuthorRepository
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        //Get all authors
        public Task<IEnumerable<Author>> GetAllAuthors();

        //Get an author with all his books
        Task<IEnumerable<Author>> GetAuthorWithBooksByNameAsync(string AuthorFirstName, string AuthorLastName);
        Task<Author> GetById(Guid id);
    }
}
