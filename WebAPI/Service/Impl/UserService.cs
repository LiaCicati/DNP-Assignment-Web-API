using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Persistence;

namespace WebAPI.Service.Impl
{
    public class UserService : IUserService
    {
        private AdultsDbContext _ctx;

        public UserService(AdultsDbContext context)
        {
            this._ctx = context;
        }
        

        public async Task<User> ValidateUser(string userName, string password)
        {
            return await _ctx.Users.FirstAsync(user => user.UserName == userName && user.Password == password);
        }
    }
}