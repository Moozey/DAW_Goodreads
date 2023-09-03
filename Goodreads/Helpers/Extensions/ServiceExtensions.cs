using Goodreads.Data.UnitOfWork;
using Goodreads.Helpers.JwtUtils;
using Goodreads.Helpers.Seeders;
using Goodreads.Repositories.AuthorRepository;
using Goodreads.Repositories.BookRepository;
using Goodreads.Repositories.UserRepository;
using Goodreads.Services.AuthorService;
using Goodreads.Services.BookService;
using Goodreads.Services.UserService;

namespace Goodreads.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IUserService, UserService>();

            return services;
        }

        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            services.AddTransient<AuthorSeeder>();
            services.AddTransient<BookSeeder>();

            return services;
        }
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
        public static IServiceCollection AddJwtUtils(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtils, JwtUtils.JwtUtils>();

            return services;
        }
    }
}
