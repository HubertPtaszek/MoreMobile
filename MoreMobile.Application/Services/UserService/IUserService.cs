using MoreMobile.Application.Models;

namespace MoreMobile.Application.Services
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAll();

        Task<UserDTO?> Get(string email);

        Task<UserDTO?> Update(UserDTO user);

        Task Delete(string email);
    }
}