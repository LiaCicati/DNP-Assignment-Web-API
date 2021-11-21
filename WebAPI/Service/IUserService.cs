using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Service
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string password);
    }
}