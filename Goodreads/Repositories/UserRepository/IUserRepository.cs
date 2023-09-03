using Goodreads.Models;
using Goodreads.Repositories.GenericRepository;

namespace Goodreads.Repositories.UserRepository
{
    public interface IUserRepository: IGenericRepository<User>
    {
        User FindByUsername(string username);
    }
}
