using Goodreads.Repositories.AuthorRepository;
using Goodreads.Repositories.BookRepository;
using Goodreads.Services.AuthorService;
using Goodreads.Services.BookService;

namespace Goodreads.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IAuthorService, AuthorService>();

            return services;
        }
    }
}
