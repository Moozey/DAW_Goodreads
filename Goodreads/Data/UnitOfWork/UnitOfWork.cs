using Goodreads.Repositories.AuthorRepository;
using Goodreads.Repositories.BookRepository;

namespace Goodreads.Data.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        public IBookRepository BookRepository { get; set; }
        public IAuthorRepository AuthorRepository { get; set; }
        

        private GoodreadsContext _context { get; set; }

        public UnitOfWork(IBookRepository bookRepository, IAuthorRepository authorRepository, GoodreadsContext context)
        {
            BookRepository = bookRepository;
            AuthorRepository = authorRepository;

            _context = context;
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() != 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
