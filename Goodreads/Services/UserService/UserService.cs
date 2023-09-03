using Goodreads.Data.UnitOfWork;
using Goodreads.Helpers.JwtUtils;
using Goodreads.Models.DTOs;
using Goodreads.Models;
using Goodreads.Repositories.UserRepository;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Goodreads.Services.UserService
{
    public class UserService: IUserService
    {
        public IUserRepository _userRepository;
        public IJwtUtils _jwtUtils;
        public IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IJwtUtils jwtUtils)
        {
            _userRepository = userRepository;
            _jwtUtils = jwtUtils;
        }

        public UserResponseDTO Authenticate(UserRequestDTO model)
        {
            var user = _userRepository.FindByUsername(model.Username);
            if (user == null || !BCryptNet.Verify(model.Password, user.Password))
            {
                return null;
            }

            var token = _jwtUtils.GenerateJwtToken(user);
            return new UserResponseDTO(user, token);
        }

        public async Task Create(User newUser)
        {
            await _userRepository.CreateAsync(newUser);
            await _userRepository.SaveAsync();
        }

        public async Task Delete(User userToDelete)
        {
            _userRepository.Delete(userToDelete);
            await _unitOfWork.SaveAsync();

        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllAsync();
        }

        public bool Save()
        {
            return _userRepository.Save();
        }

        public async Task Update(User userToUpdate)
        {
            _userRepository.Update(userToUpdate);
            await _unitOfWork.SaveAsync();

        }
        public User GetById(Guid id)
        {
            return _userRepository.FindById(id);
        }
    }
}
