using Goodreads.Data;
using Goodreads.Models;
using Goodreads.Repositories.GenericRepository;

namespace Goodreads.Repositories.UserPreferenceRepository
{
    public class UserPrivateRepository : GenericRepository<UserPrivateDetails>, IUserPrivateRepository
    {
        public UserPrivateRepository(GoodreadsContext context) : base(context)
        {
        }
        public UserPrivateDetails GetPrivateInfoByUsername(string username)
        {
            return _entities.FirstOrDefault(info => info.User.Username == username);
        }
    }
}
