using Goodreads.Data;
using Goodreads.Models;
using Goodreads.Repositories.GenericRepository;

namespace Goodreads.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    { 
        
        public UserRepository(GoodreadsContext context): base(context) 
        {

        }
        public User FindByUsername(string username)
        {
            return _entities.FirstOrDefault(x => x.Username == username);
        }
    }
}
