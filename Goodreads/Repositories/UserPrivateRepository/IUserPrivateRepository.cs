using Goodreads.Models;
using Goodreads.Repositories.GenericRepository;

namespace Goodreads.Repositories.UserPreferenceRepository
{
    public interface IUserPrivateRepository : IGenericRepository<UserPrivateDetails>
    {
        UserPrivateDetails GetPrivateInfoByUsername(string username);
    }
}

