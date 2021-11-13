using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface IUserService
    {
        Task<User> AddUserAsync(User user);
        Task<User> ValidateUser(string userName, string password);
    }
}