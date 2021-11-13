using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAPI.Models;
using WebAPI.Persistence;

namespace WebAPI.Data.Impl
{
    public class UserService : IUserService
    {
        private AdultsDbContext _ctx;

        public UserService(AdultsDbContext context)
        {
            this._ctx = context;
        }


        public async Task<User> AddUserAsync(User user)
        {
            EntityEntry<User> newlyAdded = await _ctx.Users.AddAsync(user);
            await _ctx.SaveChangesAsync();
            return newlyAdded.Entity;
        }

        public async Task<User> ValidateUser(string userName, string password)
        {
            return await _ctx.Users.FirstAsync(user => user.UserName == userName && user.Password == password);
        }
    }
}