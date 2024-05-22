using MoreMobile.Application.Models;
using MoreMobile.Data.Repositories;
using MoreMobile.Domain.Entities;

namespace MoreMobile.Application.Services
{
    public class UserService : IUserService
    {
        public IUserRepository UserRepository { get; set; }

        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public async Task<List<UserDTO>> GetAll()
        {
            var users = await UserRepository.GetAllAsync();

            return users.Select(x => new UserDTO()
            {
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber
            }).ToList();
        }

        public async Task<UserDTO?> Get(string email)
        {
            User user = await UserRepository.GetSingleAsync(x => x.Email == email);
            if (user == null)
                return null;
            return new UserDTO { Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, PhoneNumber = user.PhoneNumber };
        }

        public async Task<UserDTO?> Update(UserDTO request)
        {
            User user = await UserRepository.GetSingleAsync(x => x.Email == request.Email);
            if (user is null)
                return null;

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.PhoneNumber = request.PhoneNumber;
            user.Email = request.Email;

            UserRepository.Edit(user);
            await UserRepository.SaveAsync();

            return request;
        }

        public async Task Delete(string email)
        {
            User user = await UserRepository.GetSingleAsync(x => x.Email == email);
            if (user is null)
                return;

            UserRepository.Delete(user);
            await UserRepository.SaveAsync();

            return;
        }
    }
}