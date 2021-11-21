using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAPI.Models;
using WebAPI.Persistence;

namespace WebAPI.Data.Impl
{
    public class UserRepository : IUserRepository
    {
        private AdultsDbContext _ctx;

        public UserRepository(AdultsDbContext context)
        {
            this._ctx = context;
        }
        
        public async Task<User> AddUserAsync(User user)
        {
            EntityEntry<User> newlyAdded = await _ctx.Users.AddAsync(user);
            await _ctx.SaveChangesAsync();
            return newlyAdded.Entity;
        }
        
   
    }
}