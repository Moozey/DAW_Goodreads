using Goodreads.Models.DTOs;
using Goodreads.Models;

namespace Goodreads.Services.UserService
{
    public interface IUserService
    {
        UserResponseDTO Authenticate(UserRequestDTO model);
        User GetById(Guid id);
        Task Create(User newUser);
        Task<List<User>> GetAllUsers();
        Task Delete(User userToDelete);
        Task Update(User userToUpdate);
        bool Save();
    }
}
