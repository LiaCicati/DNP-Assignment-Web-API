using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);
     
    
    }
}